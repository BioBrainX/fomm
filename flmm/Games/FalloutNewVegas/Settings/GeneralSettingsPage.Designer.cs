﻿namespace Fomm.Games.FalloutNewVegas.Settings
{
	partial class GeneralSettingsPage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxWorkingDirectory = new System.Windows.Forms.TextBox();
			this.butSelectWorkingDirectory = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbxCommandArguments = new System.Windows.Forms.TextBox();
			this.tbxCommand = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.fbdWorkingDirectory = new System.Windows.Forms.FolderBrowserDialog();
			this.rdcDirectories = new Fomm.Games.FalloutNewVegas.Settings.RequiredDirectoriesControl();
			this.erpErrors = new System.Windows.Forms.ErrorProvider(this.components);
			this.cbxBoldifyESMs = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.erpErrors)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "New Vegas Directory:";
			// 
			// tbxWorkingDirectory
			// 
			this.tbxWorkingDirectory.Location = new System.Drawing.Point(119, 94);
			this.tbxWorkingDirectory.Name = "tbxWorkingDirectory";
			this.tbxWorkingDirectory.Size = new System.Drawing.Size(219, 20);
			this.tbxWorkingDirectory.TabIndex = 1;
			// 
			// butSelectWorkingDirectory
			// 
			this.butSelectWorkingDirectory.AutoSize = true;
			this.butSelectWorkingDirectory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butSelectWorkingDirectory.Location = new System.Drawing.Point(344, 92);
			this.butSelectWorkingDirectory.Name = "butSelectWorkingDirectory";
			this.butSelectWorkingDirectory.Size = new System.Drawing.Size(26, 23);
			this.butSelectWorkingDirectory.TabIndex = 2;
			this.butSelectWorkingDirectory.Text = "...";
			this.butSelectWorkingDirectory.UseVisualStyleBackColor = true;
			this.butSelectWorkingDirectory.Click += new System.EventHandler(this.butSelectWorkingDirectory_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Command:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbxCommandArguments);
			this.groupBox1.Controls.Add(this.tbxCommand);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(24, 121);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(346, 78);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Custom Launch Command";
			// 
			// tbxCommandArguments
			// 
			this.tbxCommandArguments.Location = new System.Drawing.Point(79, 45);
			this.tbxCommandArguments.Name = "tbxCommandArguments";
			this.tbxCommandArguments.Size = new System.Drawing.Size(257, 20);
			this.tbxCommandArguments.TabIndex = 5;
			// 
			// tbxCommand
			// 
			this.tbxCommand.Location = new System.Drawing.Point(79, 19);
			this.tbxCommand.Name = "tbxCommand";
			this.tbxCommand.Size = new System.Drawing.Size(257, 20);
			this.tbxCommand.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Arguments:";
			// 
			// rdcDirectories
			// 
			this.rdcDirectories.Location = new System.Drawing.Point(0, 3);
			this.rdcDirectories.Name = "rdcDirectories";
			this.rdcDirectories.Size = new System.Drawing.Size(393, 85);
			this.rdcDirectories.TabIndex = 0;
			// 
			// erpErrors
			// 
			this.erpErrors.ContainerControl = this;
			// 
			// cbxBoldifyESMs
			// 
			this.cbxBoldifyESMs.AutoSize = true;
			this.cbxBoldifyESMs.Location = new System.Drawing.Point(24, 210);
			this.cbxBoldifyESMs.Name = "cbxBoldifyESMs";
			this.cbxBoldifyESMs.Size = new System.Drawing.Size(137, 17);
			this.cbxBoldifyESMs.TabIndex = 5;
			this.cbxBoldifyESMs.Text = "Show ESM files in bold.";
			this.cbxBoldifyESMs.UseVisualStyleBackColor = true;
			// 
			// GeneralSettingsPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.cbxBoldifyESMs);
			this.Controls.Add(this.rdcDirectories);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.butSelectWorkingDirectory);
			this.Controls.Add(this.tbxWorkingDirectory);
			this.Controls.Add(this.label2);
			this.Name = "GeneralSettingsPage";
			this.Size = new System.Drawing.Size(403, 295);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.erpErrors)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxWorkingDirectory;
		private System.Windows.Forms.Button butSelectWorkingDirectory;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbxCommandArguments;
		private System.Windows.Forms.TextBox tbxCommand;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.FolderBrowserDialog fbdWorkingDirectory;
		private RequiredDirectoriesControl rdcDirectories;
		private System.Windows.Forms.ErrorProvider erpErrors;
		private System.Windows.Forms.CheckBox cbxBoldifyESMs;

	}
}
