
namespace Permis_de_Construction.Imprimer
{
    partial class PrintCarte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ComboBoxNom = new Guna.UI2.WinForms.Guna2ComboBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gunaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.gunaPanel1.Controls.Add(this.ComboBoxNom);
            this.gunaPanel1.Controls.Add(this.guna2ControlBox1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(678, 53);
            this.gunaPanel1.TabIndex = 1;
            this.gunaPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaPanel1_Paint);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(641, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(34, 24);
            this.guna2ControlBox1.TabIndex = 74;
            // 
            // ComboBoxNom
            // 
            this.ComboBoxNom.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxNom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxNom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxNom.FocusedColor = System.Drawing.Color.Empty;
            this.ComboBoxNom.FocusedState.Parent = this.ComboBoxNom;
            this.ComboBoxNom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboBoxNom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboBoxNom.FormattingEnabled = true;
            this.ComboBoxNom.HoverState.Parent = this.ComboBoxNom;
            this.ComboBoxNom.ItemHeight = 30;
            this.ComboBoxNom.ItemsAppearance.Parent = this.ComboBoxNom;
            this.ComboBoxNom.Location = new System.Drawing.Point(186, 8);
            this.ComboBoxNom.Name = "ComboBoxNom";
            this.ComboBoxNom.ShadowDecoration.Parent = this.ComboBoxNom;
            this.ComboBoxNom.Size = new System.Drawing.Size(295, 36);
            this.ComboBoxNom.TabIndex = 75;
            this.ComboBoxNom.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNom_SelectedIndexChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 53);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(678, 453);
            this.crystalReportViewer1.TabIndex = 2;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PrintCarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 506);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.gunaPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrintCarte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintCarte";
            this.Load += new System.EventHandler(this.PrintCarte_Load);
            this.gunaPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxNom;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}