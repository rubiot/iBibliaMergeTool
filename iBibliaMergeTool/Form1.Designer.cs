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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
      this.gtFilterType = new System.Windows.Forms.GroupBox();
      this.rbAdvancedFilter = new System.Windows.Forms.RadioButton();
      this.rbSimpleFilter = new System.Windows.Forms.RadioButton();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbFieldSrcText = new System.Windows.Forms.CheckBox();
      this.cbFieldDstText = new System.Windows.Forms.CheckBox();
      this.cbFieldPairs = new System.Windows.Forms.CheckBox();
      this.cbFieldComments = new System.Windows.Forms.CheckBox();
      this.cbFieldStatus = new System.Windows.Forms.CheckBox();
      this.gtFilterType.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tbSrcProject
      // 
      this.tbSrcProject.AllowDrop = true;
      this.tbSrcProject.Location = new System.Drawing.Point(126, 12);
      this.tbSrcProject.Name = "tbSrcProject";
      this.tbSrcProject.ReadOnly = true;
      this.tbSrcProject.Size = new System.Drawing.Size(542, 22);
      this.tbSrcProject.TabIndex = 0;
      // 
      // tbDstProject
      // 
      this.tbDstProject.Location = new System.Drawing.Point(126, 40);
      this.tbDstProject.Name = "tbDstProject";
      this.tbDstProject.ReadOnly = true;
      this.tbDstProject.Size = new System.Drawing.Size(542, 22);
      this.tbDstProject.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(23, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Projeto origem";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(20, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(103, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "Projeto destino";
      // 
      // btnOpenSrcProject
      // 
      this.btnOpenSrcProject.Location = new System.Drawing.Point(674, 11);
      this.btnOpenSrcProject.Name = "btnOpenSrcProject";
      this.btnOpenSrcProject.Size = new System.Drawing.Size(205, 23);
      this.btnOpenSrcProject.TabIndex = 3;
      this.btnOpenSrcProject.Text = "Abrir...";
      this.btnOpenSrcProject.UseVisualStyleBackColor = true;
      this.btnOpenSrcProject.Click += new System.EventHandler(this.btnOpenSrcProject_Click);
      // 
      // btnOpenDstProject
      // 
      this.btnOpenDstProject.Location = new System.Drawing.Point(674, 40);
      this.btnOpenDstProject.Name = "btnOpenDstProject";
      this.btnOpenDstProject.Size = new System.Drawing.Size(205, 23);
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
      this.tbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbFilter.Location = new System.Drawing.Point(126, 83);
      this.tbFilter.Name = "tbFilter";
      this.tbFilter.Size = new System.Drawing.Size(542, 27);
      this.tbFilter.TabIndex = 4;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(84, 83);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(39, 17);
      this.label3.TabIndex = 5;
      this.label3.Text = "Filtro";
      // 
      // btnPreview
      // 
      this.btnPreview.Location = new System.Drawing.Point(674, 83);
      this.btnPreview.Name = "btnPreview";
      this.btnPreview.Size = new System.Drawing.Size(205, 23);
      this.btnPreview.TabIndex = 6;
      this.btnPreview.Text = "Testar filtro";
      this.btnPreview.UseVisualStyleBackColor = true;
      this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
      // 
      // lbRefs
      // 
      this.lbRefs.FormattingEnabled = true;
      this.lbRefs.ItemHeight = 16;
      this.lbRefs.Location = new System.Drawing.Point(126, 176);
      this.lbRefs.Name = "lbRefs";
      this.lbRefs.Size = new System.Drawing.Size(542, 196);
      this.lbRefs.TabIndex = 7;
      // 
      // btnMerge
      // 
      this.btnMerge.AutoSize = true;
      this.btnMerge.Location = new System.Drawing.Point(674, 345);
      this.btnMerge.Name = "btnMerge";
      this.btnMerge.Size = new System.Drawing.Size(200, 27);
      this.btnMerge.TabIndex = 8;
      this.btnMerge.Text = "Mesclar projetos!";
      this.btnMerge.UseVisualStyleBackColor = true;
      this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
      // 
      // gtFilterType
      // 
      this.gtFilterType.Controls.Add(this.rbAdvancedFilter);
      this.gtFilterType.Controls.Add(this.rbSimpleFilter);
      this.gtFilterType.Location = new System.Drawing.Point(126, 118);
      this.gtFilterType.Name = "gtFilterType";
      this.gtFilterType.Size = new System.Drawing.Size(542, 52);
      this.gtFilterType.TabIndex = 9;
      this.gtFilterType.TabStop = false;
      this.gtFilterType.Text = "Tipo de filtro";
      // 
      // rbAdvancedFilter
      // 
      this.rbAdvancedFilter.AutoSize = true;
      this.rbAdvancedFilter.Location = new System.Drawing.Point(254, 22);
      this.rbAdvancedFilter.Name = "rbAdvancedFilter";
      this.rbAdvancedFilter.Size = new System.Drawing.Size(221, 21);
      this.rbAdvancedFilter.TabIndex = 1;
      this.rbAdvancedFilter.Text = "Avançado (Expressão regular)";
      this.rbAdvancedFilter.UseVisualStyleBackColor = true;
      // 
      // rbSimpleFilter
      // 
      this.rbSimpleFilter.AutoSize = true;
      this.rbSimpleFilter.Checked = true;
      this.rbSimpleFilter.Location = new System.Drawing.Point(15, 22);
      this.rbSimpleFilter.Name = "rbSimpleFilter";
      this.rbSimpleFilter.Size = new System.Drawing.Size(146, 21);
      this.rbSimpleFilter.TabIndex = 0;
      this.rbSimpleFilter.TabStop = true;
      this.rbSimpleFilter.Text = "Simples (Máscara)";
      this.rbSimpleFilter.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cbFieldStatus);
      this.groupBox1.Controls.Add(this.cbFieldComments);
      this.groupBox1.Controls.Add(this.cbFieldPairs);
      this.groupBox1.Controls.Add(this.cbFieldDstText);
      this.groupBox1.Controls.Add(this.cbFieldSrcText);
      this.groupBox1.Location = new System.Drawing.Point(675, 118);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(200, 212);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Campos";
      // 
      // cbFieldSrcText
      // 
      this.cbFieldSrcText.AutoSize = true;
      this.cbFieldSrcText.Location = new System.Drawing.Point(16, 28);
      this.cbFieldSrcText.Name = "cbFieldSrcText";
      this.cbFieldSrcText.Size = new System.Drawing.Size(112, 21);
      this.cbFieldSrcText.TabIndex = 0;
      this.cbFieldSrcText.Text = "Texto origem";
      this.cbFieldSrcText.UseVisualStyleBackColor = true;
      // 
      // cbFieldDstText
      // 
      this.cbFieldDstText.AutoSize = true;
      this.cbFieldDstText.Location = new System.Drawing.Point(16, 63);
      this.cbFieldDstText.Name = "cbFieldDstText";
      this.cbFieldDstText.Size = new System.Drawing.Size(115, 21);
      this.cbFieldDstText.TabIndex = 1;
      this.cbFieldDstText.Text = "Texto destino";
      this.cbFieldDstText.UseVisualStyleBackColor = true;
      // 
      // cbFieldPairs
      // 
      this.cbFieldPairs.AutoSize = true;
      this.cbFieldPairs.Checked = true;
      this.cbFieldPairs.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbFieldPairs.Location = new System.Drawing.Point(16, 99);
      this.cbFieldPairs.Name = "cbFieldPairs";
      this.cbFieldPairs.Size = new System.Drawing.Size(102, 21);
      this.cbFieldPairs.TabIndex = 2;
      this.cbFieldPairs.Text = "Associação";
      this.cbFieldPairs.UseVisualStyleBackColor = true;
      // 
      // cbFieldComments
      // 
      this.cbFieldComments.AutoSize = true;
      this.cbFieldComments.Checked = true;
      this.cbFieldComments.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbFieldComments.Location = new System.Drawing.Point(16, 135);
      this.cbFieldComments.Name = "cbFieldComments";
      this.cbFieldComments.Size = new System.Drawing.Size(109, 21);
      this.cbFieldComments.TabIndex = 3;
      this.cbFieldComments.Text = "Comentários";
      this.cbFieldComments.UseVisualStyleBackColor = true;
      // 
      // cbFieldStatus
      // 
      this.cbFieldStatus.AutoSize = true;
      this.cbFieldStatus.Checked = true;
      this.cbFieldStatus.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbFieldStatus.Location = new System.Drawing.Point(16, 173);
      this.cbFieldStatus.Name = "cbFieldStatus";
      this.cbFieldStatus.Size = new System.Drawing.Size(74, 21);
      this.cbFieldStatus.TabIndex = 4;
      this.cbFieldStatus.Text = "Estado";
      this.cbFieldStatus.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(891, 400);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.gtFilterType);
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
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "iBiblia - Utilitário para mesclar projetos";
      this.gtFilterType.ResumeLayout(false);
      this.gtFilterType.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
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
    private System.Windows.Forms.GroupBox gtFilterType;
    private System.Windows.Forms.RadioButton rbAdvancedFilter;
    private System.Windows.Forms.RadioButton rbSimpleFilter;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox cbFieldComments;
    private System.Windows.Forms.CheckBox cbFieldPairs;
    private System.Windows.Forms.CheckBox cbFieldDstText;
    private System.Windows.Forms.CheckBox cbFieldSrcText;
    private System.Windows.Forms.CheckBox cbFieldStatus;
  }
}

