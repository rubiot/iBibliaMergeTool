namespace iBibliaMergeTool
{
  partial class MainForm
  {
    /// <summary>
    /// Variável de designer necessária.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpar os recursos que estão sendo usados.
    /// </summary>
    /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código gerado pelo Windows Form Designer

    /// <summary>
    /// Método necessário para suporte ao Designer - não modifique 
    /// o conteúdo deste método com o editor de código.
    /// </summary>
    private void InitializeComponent()
    {
      this.tbSrcProject = new System.Windows.Forms.TextBox();
      this.tbDstProject = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOpenSrcProject = new System.Windows.Forms.Button();
      this.btnOpenDstProject = new System.Windows.Forms.Button();
      this.openProjectDialog = new System.Windows.Forms.OpenFileDialog();
      this.tbFilter = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnPreview = new System.Windows.Forms.Button();
      this.lbRefs = new System.Windows.Forms.ListBox();
      this.btnMerge = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // tbSrcProject
      // 
      this.tbSrcProject.AllowDrop = true;
      this.tbSrcProject.Location = new System.Drawing.Point(126, 12);
      this.tbSrcProject.Name = "tbSrcProject";
      this.tbSrcProject.Size = new System.Drawing.Size(605, 22);
      this.tbSrcProject.TabIndex = 0;
      // 
      // tbDstProject
      // 
      this.tbDstProject.Location = new System.Drawing.Point(126, 59);
      this.tbDstProject.Name = "tbDstProject";
      this.tbDstProject.Size = new System.Drawing.Size(605, 22);
      this.tbDstProject.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(20, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Projeto origem";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(20, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(103, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "Projeto destino";
      // 
      // btnOpenSrcProject
      // 
      this.btnOpenSrcProject.Location = new System.Drawing.Point(737, 11);
      this.btnOpenSrcProject.Name = "btnOpenSrcProject";
      this.btnOpenSrcProject.Size = new System.Drawing.Size(142, 23);
      this.btnOpenSrcProject.TabIndex = 3;
      this.btnOpenSrcProject.Text = "Abrir...";
      this.btnOpenSrcProject.UseVisualStyleBackColor = true;
      this.btnOpenSrcProject.Click += new System.EventHandler(this.btnOpenSrcProject_Click);
      // 
      // btnOpenDstProject
      // 
      this.btnOpenDstProject.Location = new System.Drawing.Point(737, 59);
      this.btnOpenDstProject.Name = "btnOpenDstProject";
      this.btnOpenDstProject.Size = new System.Drawing.Size(142, 23);
      this.btnOpenDstProject.TabIndex = 3;
      this.btnOpenDstProject.Text = "Abrir...";
      this.btnOpenDstProject.UseVisualStyleBackColor = true;
      this.btnOpenDstProject.Click += new System.EventHandler(this.btnOpenDstProject_Click);
      // 
      // openProjectDialog
      // 
      this.openProjectDialog.DefaultExt = "*.bib";
      this.openProjectDialog.Filter = "Projetos do iBiblia|*.bib";
      // 
      // tbFilter
      // 
      this.tbFilter.Location = new System.Drawing.Point(126, 106);
      this.tbFilter.Name = "tbFilter";
      this.tbFilter.Size = new System.Drawing.Size(605, 22);
      this.tbFilter.TabIndex = 4;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(73, 110);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(39, 17);
      this.label3.TabIndex = 5;
      this.label3.Text = "Filtro";
      // 
      // btnPreview
      // 
      this.btnPreview.Location = new System.Drawing.Point(738, 106);
      this.btnPreview.Name = "btnPreview";
      this.btnPreview.Size = new System.Drawing.Size(142, 23);
      this.btnPreview.TabIndex = 6;
      this.btnPreview.Text = "Testar filtro";
      this.btnPreview.UseVisualStyleBackColor = true;
      this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
      // 
      // lbRefs
      // 
      this.lbRefs.FormattingEnabled = true;
      this.lbRefs.ItemHeight = 16;
      this.lbRefs.Location = new System.Drawing.Point(126, 145);
      this.lbRefs.Name = "lbRefs";
      this.lbRefs.Size = new System.Drawing.Size(605, 244);
      this.lbRefs.TabIndex = 7;
      // 
      // btnMerge
      // 
      this.btnMerge.AutoSize = true;
      this.btnMerge.Location = new System.Drawing.Point(126, 406);
      this.btnMerge.Name = "btnMerge";
      this.btnMerge.Size = new System.Drawing.Size(125, 27);
      this.btnMerge.TabIndex = 8;
      this.btnMerge.Text = "Mesclar projetos!";
      this.btnMerge.UseVisualStyleBackColor = true;
      this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(891, 464);
      this.Controls.Add(this.btnMerge);
      this.Controls.Add(this.lbRefs);
      this.Controls.Add(this.btnPreview);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.tbFilter);
      this.Controls.Add(this.btnOpenDstProject);
      this.Controls.Add(this.btnOpenSrcProject);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbDstProject);
      this.Controls.Add(this.tbSrcProject);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "iBiblia - Utilitário para mesclar projetos";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbSrcProject;
    private System.Windows.Forms.TextBox tbDstProject;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnOpenSrcProject;
    private System.Windows.Forms.Button btnOpenDstProject;
    private System.Windows.Forms.OpenFileDialog openProjectDialog;
    private System.Windows.Forms.TextBox tbFilter;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnPreview;
    private System.Windows.Forms.ListBox lbRefs;
    private System.Windows.Forms.Button btnMerge;
  }
}

