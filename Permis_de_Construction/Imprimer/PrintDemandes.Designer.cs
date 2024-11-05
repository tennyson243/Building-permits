
namespace Permis_de_Construction.Imprimer
{
    partial class PrintDemandes
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
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.DateTimePickerdudate = new Guna.UI.WinForms.GunaDateTimePicker();
            this.DateTimeAudate = new Guna.UI.WinForms.GunaDateTimePicker();
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
            this.gunaPanel1.Controls.Add(this.DateTimeAudate);
            this.gunaPanel1.Controls.Add(this.DateTimePickerdudate);
            this.gunaPanel1.Controls.Add(this.guna2ControlBox1);
            this.gunaPanel1.Controls.Add(this.label1);
            this.gunaPanel1.Controls.Add(this.label7);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(800, 53);
            this.gunaPanel1.TabIndex = 0;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(763, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(34, 24);
            this.guna2ControlBox1.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(65, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 21);
            this.label1.TabIndex = 73;
            this.label1.Text = "Du";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(336, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 21);
            this.label7.TabIndex = 70;
            this.label7.Text = "Au";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 53);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 462);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // DateTimePickerdudate
            // 
            this.DateTimePickerdudate.BaseColor = System.Drawing.Color.White;
            this.DateTimePickerdudate.BorderColor = System.Drawing.Color.Silver;
            this.DateTimePickerdudate.CustomFormat = null;
            this.DateTimePickerdudate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DateTimePickerdudate.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DateTimePickerdudate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateTimePickerdudate.ForeColor = System.Drawing.Color.Black;
            this.DateTimePickerdudate.Location = new System.Drawing.Point(106, 9);
            this.DateTimePickerdudate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTimePickerdudate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTimePickerdudate.Name = "DateTimePickerdudate";
            this.DateTimePickerdudate.OnHoverBaseColor = System.Drawing.Color.White;
            this.DateTimePickerdudate.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DateTimePickerdudate.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DateTimePickerdudate.OnPressedColor = System.Drawing.Color.Black;
            this.DateTimePickerdudate.Size = new System.Drawing.Size(223, 35);
            this.DateTimePickerdudate.TabIndex = 75;
            this.DateTimePickerdudate.Text = "mercredi 6 décembre 2023";
            this.DateTimePickerdudate.Value = new System.DateTime(2023, 12, 6, 11, 50, 37, 418);
            // 
            // DateTimeAudate
            // 
            this.DateTimeAudate.BaseColor = System.Drawing.Color.White;
            this.DateTimeAudate.BorderColor = System.Drawing.Color.Silver;
            this.DateTimeAudate.CustomFormat = null;
            this.DateTimeAudate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DateTimeAudate.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DateTimeAudate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateTimeAudate.ForeColor = System.Drawing.Color.Black;
            this.DateTimeAudate.Location = new System.Drawing.Point(390, 8);
            this.DateTimeAudate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTimeAudate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTimeAudate.Name = "DateTimeAudate";
            this.DateTimeAudate.OnHoverBaseColor = System.Drawing.Color.White;
            this.DateTimeAudate.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DateTimeAudate.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DateTimeAudate.OnPressedColor = System.Drawing.Color.Black;
            this.DateTimeAudate.Size = new System.Drawing.Size(262, 35);
            this.DateTimeAudate.TabIndex = 76;
            this.DateTimeAudate.Text = "mercredi 6 décembre 2023";
            this.DateTimeAudate.Value = new System.DateTime(2023, 12, 6, 11, 50, 39, 321);
            // 
            // PrintDemandes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.gunaPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrintDemandes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintDemandes";
            this.Load += new System.EventHandler(this.PrintDemandes_Load);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI.WinForms.GunaDateTimePicker DateTimeAudate;
        private Guna.UI.WinForms.GunaDateTimePicker DateTimePickerdudate;
    }
}