using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Resources;
using System.Globalization;
using System.Text.RegularExpressions;

namespace iBibliaMergeTool
{
  public partial class MainForm : Form
  {
    private SQLiteConnection m_srcProject;
    private SQLiteConnection m_dstProject;

    public MainForm()
    {
      InitializeComponent();
    }

    ~MainForm()
    {
      m_srcProject.Close();
      m_dstProject.Close();
    }

    private SQLiteConnection CreateConnection(string dbName)
    {
      SQLiteConnection conn = new SQLiteConnection($"Data Source={dbName};Version=3;UseUTF8Encoding=True;");

      conn.Open();

      SQLiteFunction function1 = new RegExSQLiteFunction();
      var attributes1 = function1.GetType().GetCustomAttributes(typeof(SQLiteFunctionAttribute), true).Cast<SQLiteFunctionAttribute>().ToArray();
      if (attributes1.Length == 0)
      {
        throw new InvalidOperationException("SQLiteFunction doesn't have SQLiteFunctionAttribute");
      }
      conn.BindFunction(attributes1[0], function1);

      var function2 = new MaskSQLiteFunction();
      var attributes2 = function2.GetType().GetCustomAttributes(typeof(SQLiteFunctionAttribute), true).Cast<SQLiteFunctionAttribute>().ToArray();
      if (attributes2.Length == 0)
      {
        throw new InvalidOperationException("SQLiteFunction doesn't have SQLiteFunctionAttribute");
      }
      conn.BindFunction(attributes2[0], function2);

      var function3 = new MySortSQLiteFunction();
      var attributes3 = function3.GetType().GetCustomAttributes(typeof(SQLiteFunctionAttribute), true).Cast<SQLiteFunctionAttribute>().ToArray();
      if (attributes3.Length == 0)
      {
        throw new InvalidOperationException("SQLiteFunction doesn't have SQLiteFunctionAttribute");
      }
      conn.BindFunction(attributes3[0], function3);

      return conn;
    }

    private void btnOpenSrcProject_Click(object sender, EventArgs e)
    {
      if (openProjectDialog.ShowDialog() == DialogResult.OK)
      {
        tbSrcProject.Text = openProjectDialog.FileName;
        m_srcProject = CreateConnection(openProjectDialog.FileName);
      }
    }

    private void btnOpenDstProject_Click(object sender, EventArgs e)
    {
      if (openProjectDialog.ShowDialog() == DialogResult.OK)
      {
        tbDstProject.Text = openProjectDialog.FileName;
        m_dstProject = CreateConnection(openProjectDialog.FileName);
      }
    }

    private void btnPreview_Click(object sender, EventArgs e)
    {
      if (tbSrcProject.TextLength == 0)
      {
        MessageBox.Show(GlobalData.ResourceSet.GetString("ChooseASourceProject"));
        return;
      }

      if (tbFilter.TextLength == 0)
      {
        MessageBox.Show(GlobalData.ResourceSet.GetString("ChooseAFilter"));
        return;
      }

      SQLiteCommand command = MakeSelectStmt("pare_id");

      try
      {
        SQLiteDataReader reader = command.ExecuteReader();

        lbRefs.Items.Clear();
        while (reader.Read())
          lbRefs.Items.Add(GlobalData.MakeReference(reader["pare_id"].ToString()));

        if (lbRefs.Items.Count == 0)
          lbRefs.Items.Add(GlobalData.ResourceSet.GetString("EmptyFilterResults"));
      }
      catch (Exception ex)
      {
        MessageBox.Show(GlobalData.ResourceSet.GetString("UnexpectedFilterError") + ex.Message);
        return;
      }
    }

    private SQLiteCommand MakeSelectStmt(string fields)
    {
      string op = rbSimpleFilter.Checked ? "MATCH" : "REGEXP";
      string stmt = $@"SELECT {fields}
                       FROM pares
                       WHERE pare_id {op} '{tbFilter.Text}'
                       ORDER BY MYSORT(pare_id)";

      return new SQLiteCommand(stmt, m_srcProject);
    }

    private SQLiteCommand MakeUpdateStmt()
    {
      List<string> fields = new List<string>();

      if (cbFieldSrcText.Checked)
        fields.Add("pare_texto_origem = @pare_texto_origem");
      if (cbFieldDstText.Checked)
        fields.Add("pare_texto_destino = @pare_texto_destino");
      if (cbFieldPairs.Checked)
        fields.Add("pare_pares = @pare_pares");
      if (cbFieldStatus.Checked)
        fields.Add("pare_situacao = @pare_situacao");
      if (cbFieldComments.Checked)
        fields.Add("pare_comentarios = @pare_comentarios");

      if (fields.Count == 0)
        throw new Exception(GlobalData.ResourceSet.GetString("ChooseAtLeatOneField"));

      string stmt = $"UPDATE pares SET { String.Join(", ", fields.ToArray()) } WHERE pare_id = @pare_id";

      SQLiteCommand update = new SQLiteCommand(stmt, m_dstProject);

      if (cbFieldSrcText.Checked)
        update.Parameters.Add(new SQLiteParameter("@pare_texto_origem", DbType.String));
      if (cbFieldDstText.Checked)
        update.Parameters.Add(new SQLiteParameter("@pare_texto_destino", DbType.String));
      if (cbFieldPairs.Checked)
        update.Parameters.Add(new SQLiteParameter("@pare_pares", DbType.String));
      if (cbFieldStatus.Checked)
        update.Parameters.Add(new SQLiteParameter("@pare_situacao", DbType.String));
      if (cbFieldComments.Checked)
        update.Parameters.Add(new SQLiteParameter("@pare_comentarios", DbType.String));
      update.Parameters.Add(new SQLiteParameter("@pare_id", DbType.String));

      return update;
    }

    private void btnMerge_Click(object sender, EventArgs e)
    {
      if (tbSrcProject.TextLength == 0)
      {
        MessageBox.Show(GlobalData.ResourceSet.GetString("ChooseASourceProject"));
        return;
      }

      if (tbDstProject.TextLength == 0)
      {
        MessageBox.Show(GlobalData.ResourceSet.GetString("ChooseADestinationProject"));
        return;
      }

      if (tbFilter.TextLength == 0)
      {
        MessageBox.Show(GlobalData.ResourceSet.GetString("ChooseAFilter"));
        return;
      }

      SQLiteCommand select = MakeSelectStmt("pare_id, pare_texto_origem, pare_texto_destino, pare_pares, pare_situacao, pare_comentarios");
      SQLiteCommand update;
      try
      {
        update = MakeUpdateStmt();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        return;
      }

      lbRefs.Items.Clear();

      using (var tra = m_dstProject.BeginTransaction())
      {
        try
        {
          SQLiteDataReader reader = select.ExecuteReader();
          while (reader.Read())
          {
            lbRefs.Items.Add($"{GlobalData.ResourceSet.GetString("Copying")} {GlobalData.MakeReference(reader["pare_id"].ToString())}...");

            if (cbFieldSrcText.Checked)
              update.Parameters["@pare_texto_origem"].Value = reader["pare_texto_origem"];
            if (cbFieldDstText.Checked)
              update.Parameters["@pare_texto_destino"].Value = reader["pare_texto_destino"];
            if (cbFieldPairs.Checked)
              update.Parameters["@pare_pares"].Value = reader["pare_pares"];
            if (cbFieldStatus.Checked)
              update.Parameters["@pare_situacao"].Value = reader["pare_situacao"];
            if (cbFieldComments.Checked)
              update.Parameters["@pare_comentarios"].Value = reader["pare_comentarios"];
            update.Parameters["@pare_id"].Value = reader["pare_id"];

            update.ExecuteNonQuery();
          }
          tra.Commit();
          lbRefs.Items.Add(GlobalData.ResourceSet.GetString("MergeComplete"));
          MessageBox.Show(GlobalData.ResourceSet.GetString("MergeComplete"));
        }
        catch (Exception ex)
        {
          tra.Rollback();
          MessageBox.Show(GlobalData.ResourceSet.GetString("MergeError") + ex.Message);
        }
      }
    }
  }

  public static class GlobalData
  {
    private static ResourceSet resourceSet = MainFormStrings.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
    public static ResourceSet ResourceSet { get => resourceSet; set => resourceSet = value; }

    public static string[] BookNames =
    {
      "",
      ResourceSet.GetString("SGenesis"),        ResourceSet.GetString("SExodus"),        ResourceSet.GetString("SLeviticus"),    ResourceSet.GetString("SNumbers"),
      ResourceSet.GetString("SDeuteronomy"),    ResourceSet.GetString("SJoshua"),        ResourceSet.GetString("SJudges"),       ResourceSet.GetString("SRuth"),
      ResourceSet.GetString("S1Samuel"),        ResourceSet.GetString("S2Samuel"),       ResourceSet.GetString("S1Kings"),       ResourceSet.GetString("S2Kings"),
      ResourceSet.GetString("S1Chronicles"),    ResourceSet.GetString("S2Chronicles"),   ResourceSet.GetString("SEzra"),         ResourceSet.GetString("SNehemiah"),
      ResourceSet.GetString("SEsther"),         ResourceSet.GetString("SJob"),           ResourceSet.GetString("SPsalms"),       ResourceSet.GetString("SProverbs"),
      ResourceSet.GetString("SEcclesiastes"),   ResourceSet.GetString("SSongOfSolomon"), ResourceSet.GetString("SIsaiah"),       ResourceSet.GetString("SJeremiah"),
      ResourceSet.GetString("SLamentations"),   ResourceSet.GetString("SEzekiel"),       ResourceSet.GetString("SDaniel"),       ResourceSet.GetString("SHosea"),
      ResourceSet.GetString("SJoel"),           ResourceSet.GetString("SAmos"),          ResourceSet.GetString("SObadiah"),      ResourceSet.GetString("SJohah"),
      ResourceSet.GetString("SMicah"),          ResourceSet.GetString("SNahum"),         ResourceSet.GetString("SHabakkuk"),     ResourceSet.GetString("SZephaniah"),
      ResourceSet.GetString("SHaggai"),         ResourceSet.GetString("SZechariah"),     ResourceSet.GetString("SMalachi"),      ResourceSet.GetString("SMatthew"),
      ResourceSet.GetString("SMark"),           ResourceSet.GetString("SLuke"),          ResourceSet.GetString("SJohn"),         ResourceSet.GetString("SActs"),
      ResourceSet.GetString("SRomans"),         ResourceSet.GetString("S1Corinthians"),  ResourceSet.GetString("S2Corinthians"), ResourceSet.GetString("SGalatians"),
      ResourceSet.GetString("SEphesians"),      ResourceSet.GetString("SPhilippians"),   ResourceSet.GetString("SColossians"),   ResourceSet.GetString("S1Thessalonians"),
      ResourceSet.GetString("S2Thessalonians"), ResourceSet.GetString("S1Timothy"),      ResourceSet.GetString("S2Timothy"),     ResourceSet.GetString("STitus"),
      ResourceSet.GetString("SPhilemon"),       ResourceSet.GetString("SHebrew"),        ResourceSet.GetString("SJames"),        ResourceSet.GetString("S1Peter"),
      ResourceSet.GetString("S2Peter"),         ResourceSet.GetString("S1John"),         ResourceSet.GetString("S2John"),        ResourceSet.GetString("S3John"),
      ResourceSet.GetString("SJude"),           ResourceSet.GetString("SRevelation")
    };

    public static string MakeReference(string id)
    {
      var parts = id.Split(',');
      var bk = int.Parse(parts[0]);
      var ch = int.Parse(parts[1]);
      var vs = int.Parse(parts[2]);
      return $"{GlobalData.BookNames[bk]} {ch}:{vs}";
    }
  }

  [SQLiteFunction(Name = "MATCH", Arguments = 2, FuncType = FunctionType.Scalar)]
  public class MaskSQLiteFunction : SQLiteFunction
  {
    public override object Invoke(object[] args)
    {
      string expr = Convert.ToString(args[0]);
      string id   = GlobalData.MakeReference(Convert.ToString(args[1]));
      string pattern =
       '^' +
       Regex.Escape(expr.Replace(".", "__DOT__")
                       .Replace("*", "__STAR__")
                       .Replace("?", "__QM__"))
           .Replace("__DOT__", "[.]")
           .Replace("__STAR__", ".*")
           .Replace("__QM__", ".")
       + '$';
      return new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(id);
    }
  }

  [SQLiteFunction(Name = "REGEXP", Arguments = 2, FuncType = FunctionType.Scalar)]
  public class RegExSQLiteFunction : SQLiteFunction
  {
    public override object Invoke(object[] args)
    {
      string expr = Convert.ToString(args[0]);
      string id = GlobalData.MakeReference(Convert.ToString(args[1]));
      return Regex.IsMatch(id, expr);
    }
  }

  [SQLiteFunction(Name = "MYSORT", Arguments = 1, FuncType = FunctionType.Scalar)]
  public class MySortSQLiteFunction : SQLiteFunction
  {
    public override object Invoke(object[] args)
    {
      string id = Convert.ToString(args[0]);
      var parts = id.Split(',');
      return parts[0].PadLeft(3, '0') +
             parts[1].PadLeft(3, '0') +
             parts[2].PadLeft(3, '0');
    }
  }
}