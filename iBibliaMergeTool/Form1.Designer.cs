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
      this.cbFieldStatus = new System.Windows.Forms.CheckBox();
      this.cbFieldComments = new System.Windows.Forms.CheckBox();
      this.cbFieldPairs = new System.Windows.Forms.CheckBox();
      this.cbFieldDstText = new System.Windows.Forms.CheckBox();
      this.cbFieldSrcText = new System.Windows.Forms.CheckBox();
      this.gtFilterType.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tbSrcProject
      // 
      resources.ApplyResources(this.tbSrcProject, "tbSrcProject");
      this.tbSrcProject.AllowDrop = true;
      this.tbSrcProject.Name = "tbSrcProject";
      this.tbSrcProject.ReadOnly = true;
      // 
      // tbDstProject
      // 
      resources.ApplyResources(this.tbDstProject, "tbDstProject");
      this.tbDstProject.Name = "tbDstProject";
      this.tbDstProject.ReadOnly = true;
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // btnOpenSrcProject
      // 
      resources.ApplyResources(this.btnOpenSrcProject, "btnOpenSrcProject");
      this.btnOpenSrcProject.Name = "btnOpenSrcProject";
      this.btnOpenSrcProject.UseVisualStyleBackColor = true;
      this.btnOpenSrcProject.Click += new System.EventHandler(this.btnOpenSrcProject_Click);
      // 
      // btnOpenDstProject
      // 
      resources.ApplyResources(this.btnOpenDstProject, "btnOpenDstProject");
      this.btnOpenDstProject.Name = "btnOpenDstProject";
      this.btnOpenDstProject.UseVisualStyleBackColor = true;
      this.btnOpenDstProject.Click += new System.EventHandler(this.btnOpenDstProject_Click);
      // 
      // openProjectDialog
      // 
      this.openProjectDialog.DefaultExt = "*.bib";
      resources.ApplyResources(this.openProjectDialog, "openProjectDialog");
      // 
      // tbFilter
      // 
      resources.ApplyResources(this.tbFilter, "tbFilter");
      this.tbFilter.Name = "tbFilter";
      // 
      // label3
      // 
      resources.ApplyResources(this.label3, "label3");
      this.label3.Name = "label3";
      // 
      // btnPreview
      // 
      resources.ApplyResources(this.btnPreview, "btnPreview");
      this.btnPreview.Name = "btnPreview";
      this.btnPreview.UseVisualStyleBackColor = true;
      this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
      // 
      // lbRefs
      // 
      resources.ApplyResources(this.lbRefs, "lbRefs");
      this.lbRefs.FormattingEnabled = true;
      this.lbRefs.Name = "lbRefs";
      // 
      // btnMerge
      // 
      resources.ApplyResources(this.btnMerge, "btnMerge");
      this.btnMerge.Name = "btnMerge";
      this.btnMerge.UseVisualStyleBackColor = true;
      this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
      // 
      // gtFilterType
      // 
      resources.ApplyResources(this.gtFilterType, "gtFilterType");
      this.gtFilterType.Controls.Add(this.rbAdvancedFilter);
      this.gtFilterType.Controls.Add(this.rbSimpleFilter);
      this.gtFilterType.Name = "gtFilterType";
      this.gtFilterType.TabStop = false;
      // 
      // rbAdvancedFilter
      // 
      resources.ApplyResources(this.rbAdvancedFilter, "rbAdvancedFilter");
      this.rbAdvancedFilter.Name = "rbAdvancedFilter";
      this.rbAdvancedFilter.UseVisualStyleBackColor = true;
      // 
      // rbSimpleFilter
      // 
      resources.ApplyResources(this.rbSimpleFilter, "rbSimpleFilter");
      this.rbSimpleFilter.Checked = true;
      this.rbSimpleFilter.Name = "rbSimpleFilter";
      this.rbSimpleFilter.TabStop = true;
      this.rbSimpleFilter.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      resources.ApplyResources(this.groupBox1, "groupBox1");
      this.groupBox1.Controls.Add(this.cbFieldStatus);
      this.groupBox1.Controls.Add(this.cbFieldComments);
      this.groupBox1.Controls.Add(this.cbFieldPairs);
      this.groupBox1.Controls.Add(this.cbFieldDstText);
      this.groupBox1.Controls.Add(this.cbFieldSrcText);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      // 
      // cbFieldStatus
      // 
      resources.ApplyResources(this.cbFieldStatus, "cbFieldStatus");
      this.cbFieldStatus.Checked = true;
      this.cbFieldStatus.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbFieldStatus.Name = "cbFieldStatus";
      this.cbFieldStatus.UseVisualStyleBackColor = true;
      // 
      // cbFieldComments
      // 
      resources.ApplyResources(this.cbFieldComments, "cbFieldComments");
      this.cbFieldComments.Checked = true;
      this.cbFieldComments.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbFieldComments.Name = "cbFieldComments";
      this.cbFieldComments.UseVisualStyleBackColor = true;
      // 
      // cbFieldPairs
      // 
      resources.ApplyResources(this.cbFieldPairs, "cbFieldPairs");
      this.cbFieldPairs.Checked = true;
      this.cbFieldPairs.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbFieldPairs.Name = "cbFieldPairs";
      this.cbFieldPairs.UseVisualStyleBackColor = true;
      // 
      // cbFieldDstText
      // 
      resources.ApplyResources(this.cbFieldDstText, "cbFieldDstText");
      this.cbFieldDstText.Name = "cbFieldDstText";
      this.cbFieldDstText.UseVisualStyleBackColor = true;
      // 
      // cbFieldSrcText
      // 
      resources.ApplyResources(this.cbFieldSrcText, "cbFieldSrcText");
      this.cbFieldSrcText.Name = "cbFieldSrcText";
      this.cbFieldSrcText.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
      this.Name = "MainForm";
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

