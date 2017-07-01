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

    private void btnOpenSrcProject_Click(object sender, EventArgs e)
    {
      if (openProjectDialog.ShowDialog() == DialogResult.OK)
      {
        tbSrcProject.Text = openProjectDialog.FileName;
        m_srcProject = new SQLiteConnection("Data Source=" + openProjectDialog.FileName + ";Version=3;UseUTF8Encoding=True;");
        m_srcProject.Open();
      }
    }

    private void btnOpenDstProject_Click(object sender, EventArgs e)
    {
      if (openProjectDialog.ShowDialog() == DialogResult.OK)
      {
        m_dstProject = new SQLiteConnection("Data Source=" + openProjectDialog.FileName + ";Version=3;UseUTF8Encoding=True;");
        tbDstProject.Text = openProjectDialog.FileName;
        m_dstProject.Open();
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

      string sql = $"select pare_ref from pares where pare_ref like '{tbFilter.Text}'";
      SQLiteCommand command = new SQLiteCommand(sql, m_srcProject);

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

    private void btnMerge_Click(object sender, EventArgs e)
    {
      if (tbSrcProject.TextLength == 0)
      {
        MessageBox.Show("Erro: primeiro escolha o projeto de origem!");
        return;
      }

      if (tbDstProject.TextLength == 0)
      {
        MessageBox.Show("Erro: primeiro escolha o projeto de destino!");
        return;
      }

      if (tbFilter.TextLength == 0)
      {
        MessageBox.Show("Erro: primeiro informe o filtro a ser utilizado!");
        return;
      }
 
      string versesSelect = $@"
        SELECT
          pare_id,
          pare_ref,
          pare_texto_origem,
          pare_texto_destino,
          pare_pares,
          pare_situacao,
          pare_comentarios
        FROM pares
        WHERE pare_ref like '{tbFilter.Text}'";

      SQLiteCommand select = new SQLiteCommand(versesSelect, m_srcProject);
      SQLiteDataReader reader = select.ExecuteReader();

      string updateStmt = @"
        UPDATE pares
        SET pare_texto_origem  = @pare_texto_origem,
            pare_texto_destino = @pare_texto_destino,
            pare_pares         = @pare_pares,
            pare_situacao      = @pare_situacao,
            pare_comentarios   = @pare_comentarios
        WHERE pare_id = @pare_id";

      SQLiteCommand update = new SQLiteCommand(updateStmt, m_dstProject);
      update.Parameters.Add(new SQLiteParameter("@pare_texto_origem", DbType.String));
      update.Parameters.Add(new SQLiteParameter("@pare_texto_destino", DbType.String));
      update.Parameters.Add(new SQLiteParameter("@pare_pares", DbType.String));
      update.Parameters.Add(new SQLiteParameter("@pare_situacao", DbType.String));
      update.Parameters.Add(new SQLiteParameter("@pare_comentarios", DbType.String));
      update.Parameters.Add(new SQLiteParameter("@pare_id", DbType.String));

      lbRefs.Items.Clear();

      using (var tra = m_dstProject.BeginTransaction())
      {
        try
        {
          while (reader.Read())
          {
            lbRefs.Items.Add($"copiando {reader["pare_ref"]}...");

            update.Parameters["@pare_texto_origem"].Value  = reader["pare_texto_origem"];
            update.Parameters["@pare_texto_destino"].Value = reader["pare_texto_destino"];
            update.Parameters["@pare_pares"].Value         = reader["pare_pares"];
            update.Parameters["@pare_situacao"].Value      = reader["pare_situacao"];
            update.Parameters["@pare_comentarios"].Value   = reader["pare_comentarios"];
            update.Parameters["@pare_id"].Value            = reader["pare_id"];
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
}