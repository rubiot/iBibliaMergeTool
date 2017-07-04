using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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

      SQLiteFunction function = new RegExSQLiteFunction();
      var attributes = function.GetType().GetCustomAttributes(typeof(SQLiteFunctionAttribute), true).Cast<SQLiteFunctionAttribute>().ToArray();
      if (attributes.Length == 0)
      {
        throw new InvalidOperationException("SQLiteFunction doesn't have SQLiteFunctionAttribute");
      }
      conn.BindFunction(attributes[0], function);

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
        MessageBox.Show("Erro: primeiro escolha o projeto de origem!");
        return;
      }

      if (tbFilter.TextLength == 0)
      {
        MessageBox.Show("Erro: Preencha o campo filtro!");
        return;
      }

      SQLiteCommand command = MakeSelectStmt("pare_ref");

      try
      {
        SQLiteDataReader reader = command.ExecuteReader();

        lbRefs.Items.Clear();
        while (reader.Read())
          lbRefs.Items.Add(reader["pare_ref"]);

        if (lbRefs.Items.Count == 0)
          lbRefs.Items.Add("Seu filtro não selecionou nenhum versículo. Tente novamente.");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Ocorreu um erro durante o processo, seu filtro não parece válido: " + ex.Message);
        return;
      }
    }

    private SQLiteCommand MakeSelectStmt(string fields)
    {
      string op = rbSimpleFilter.Checked ? "LIKE" : "REGEXP";
      string stmt = $@"SELECT {fields}
                       FROM pares
                       WHERE pare_ref {op} '{tbFilter.Text}'";

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
        throw new Exception("Selecione ao menos um campo para ser mesclado");

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
        MessageBox.Show("Escolha o projeto de origem!");
        return;
      }

      if (tbDstProject.TextLength == 0)
      {
        MessageBox.Show("Escolha o projeto de destino!");
        return;
      }

      if (tbFilter.TextLength == 0)
      {
        MessageBox.Show("Informe o filtro a ser utilizado!");
        return;
      }

      SQLiteCommand select = MakeSelectStmt("pare_id, pare_ref, pare_texto_origem, pare_texto_destino, pare_pares, pare_situacao, pare_comentarios");
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
            lbRefs.Items.Add($"copiando {reader["pare_ref"]}...");

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
          lbRefs.Items.Add("Mesclagem concluída com sucesso!");
          MessageBox.Show("Mesclagem concluída com sucesso!");
        }
        catch (Exception ex)
        {
          tra.Rollback();
          MessageBox.Show("Ocorreu um erro durante o processo, mesclagem abortada: " + ex.Message);
        }
      }
    }
  }

  [SQLiteFunction(Name = "REGEXP", Arguments = 2, FuncType = FunctionType.Scalar)]
  public class RegExSQLiteFunction : SQLiteFunction
  {
    public override object Invoke(object[] args)
    {
      return System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(args[1]), Convert.ToString(args[0]));
    }
  }
}