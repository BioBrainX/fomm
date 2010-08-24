﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Drawing;

namespace Fomm.PackageManager.XmlConfiguredInstall
{
	/// <summary>
	/// The form that displays the options that were specified in the XML configuration file.
	/// </summary>
	public partial class OptionsForm : Form
	{
		private XmlConfiguredScript m_xcsScript = null;
		private DependencyStateManager m_dsmStateManager = null;
		private List<KeyValuePair<InstallStep, OptionFormStep>> m_lstInstallSteps = new List<KeyValuePair<InstallStep, OptionFormStep>>();
		private Int32 m_intCurrentStep = 0;

		/// <summary>
		/// A simple constructor that initializes the object with the given values.
		/// </summary>
		/// <param name="p_xcsScript">The install script.</param>
		/// <param name="p_hifHeaderInfo">Information describing the form header.</param>
		/// <param name="p_dsmStateManager">The install state manager.</param>
		/// <param name="p_lstInstallSteps">The install steps.</param>
		public OptionsForm(XmlConfiguredScript p_xcsScript, HeaderInfo p_hifHeaderInfo, DependencyStateManager p_dsmStateManager, IList<InstallStep> p_lstInstallSteps)
		{
			m_xcsScript = p_xcsScript;
			m_dsmStateManager = p_dsmStateManager;
			InitializeComponent();
			hplTitle.Text = p_hifHeaderInfo.Title;
			hplTitle.Image = p_hifHeaderInfo.ShowImage ? p_hifHeaderInfo.Image : null;
			hplTitle.ShowFade = p_hifHeaderInfo.ShowFade;
			hplTitle.ForeColor = p_hifHeaderInfo.TextColour;
			hplTitle.TextPosition = p_hifHeaderInfo.TextPosition;
			if (p_hifHeaderInfo.Height > hplTitle.Height)
				hplTitle.Height = p_hifHeaderInfo.Height;

			foreach (InstallStep stpStep in p_lstInstallSteps)
			{
				OptionFormStep ofsStep = new OptionFormStep(m_dsmStateManager, stpStep.GroupedPlugins);
				ofsStep.Dock = DockStyle.Fill;
				ofsStep.Visible = false;
				ofsStep.ItemChecked += new EventHandler(ofsStep_ItemChecked);
				pnlWizardSteps.Controls.Add(ofsStep);
				m_lstInstallSteps.Add(new KeyValuePair<InstallStep, OptionFormStep>(stpStep, ofsStep));
			}
			m_intCurrentStep = -1;
			StepForward();
		}

		#region Form Members

		/// <summary>
		/// Gets the list of files and folders that need to be installed.
		/// </summary>
		/// <remarks>
		/// The list returned is base upon the plugins that the user selected.
		/// </remarks>
		/// <value>The list of files and folders that need to be installed.</value>
		public List<PluginFile> FilesToInstall
		{
			get
			{
				List<PluginFile> lstInstall = new List<PluginFile>();
				foreach (KeyValuePair<InstallStep, OptionFormStep> kvpStep in m_lstInstallSteps)
				{
					if (kvpStep.Key.Visible)
					{
						lstInstall.AddRange(kvpStep.Value.FilesToInstall);
					}
				}
				lstInstall.Sort();
				return lstInstall;
			}
		}

		/// <summary>
		/// Gets the list of files, and folders that may contain files, that need to be activated.
		/// </summary>
		/// <remarks>
		/// The list returned is base upon the plugins that the user selected.
		/// </remarks>
		/// <value>The list of files, and folders that may contain files, that need to be activated.</value>
		public List<PluginFile> PluginsToActivate
		{
			get
			{
				List<PluginFile> lstActivate = new List<PluginFile>();
				foreach (KeyValuePair<InstallStep, OptionFormStep> kvpStep in m_lstInstallSteps)
				{
					if (kvpStep.Key.Visible)
					{
						lstActivate.AddRange(kvpStep.Value.PluginsToActivate);
					}
				}
				lstActivate.Sort();
				return lstActivate;
			}
		}

		/// <summary>
		/// Handles the Click event of the cancel button.
		/// </summary>
		/// <remarks>
		/// This cancels the dialog.
		/// </remarks>
		/// <param name="sender">The object that triggered the event.</param>
		/// <param name="e">An <see cref="EventArgs"/> describing the event arguments.</param>
		private void butCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		#region Navigation

		/// <summary>
		/// This updates the back/next button states.
		/// </summary>
		protected void SetWizardButtonStates()
		{
			bool booLast = true;
			for (Int32 i = m_intCurrentStep + 1; i < m_lstInstallSteps.Count; i++)
			{
				KeyValuePair<InstallStep, OptionFormStep> kvpStep = m_lstInstallSteps[i];
				if (kvpStep.Key.Visible)
				{
					booLast = false;
					break;
				}
			}
			if (booLast)
				butNext.Text = "Finish";
			else
				butNext.Text = "Next >";

			bool booFirst = true;
			for (Int32 i = m_intCurrentStep - 1; i >= 0; i--)
			{
				KeyValuePair<InstallStep, OptionFormStep> kvpStep = m_lstInstallSteps[i];
				if (kvpStep.Key.Visible)
				{
					booFirst = false;
					break;
				}
			}
			butBack.Enabled = !booFirst;
		}

		/// <summary>
		/// Advances the wizard to the next visible step, or finishes the wizard if the current step
		/// is the last visible step.
		/// </summary>
		protected void StepForward()
		{
			if (butNext.Text.Equals("Finish"))
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			for (Int32 i = m_intCurrentStep + 1; i < m_lstInstallSteps.Count; i++)
			{
				KeyValuePair<InstallStep, OptionFormStep> kvpStep = m_lstInstallSteps[i];
				if (kvpStep.Key.Visible)
				{
					if (m_intCurrentStep >= 0)
						m_lstInstallSteps[m_intCurrentStep].Value.Visible = false;
					kvpStep.Value.Visible = true;
					m_intCurrentStep = i;
					break;
				}
			}
			SetWizardButtonStates();
		}

		/// <summary>
		/// Moves the wizard to the previous visible step.
		/// </summary>
		protected void StepBack()
		{
			for (Int32 i = m_intCurrentStep - 1; i >= 0; i--)
			{
				KeyValuePair<InstallStep, OptionFormStep> kvpStep = m_lstInstallSteps[i];
				if (kvpStep.Key.Visible)
				{
					if (m_intCurrentStep < m_lstInstallSteps.Count)
						m_lstInstallSteps[m_intCurrentStep].Value.Visible = false;
					kvpStep.Value.Visible = true;
					m_intCurrentStep = i;
					break;
				}
			}
			SetWizardButtonStates();
		}

		/// <summary>
		/// Handles the <see cref="Control.Click"/> event of the next button.
		/// </summary>
		/// <param name="sender">The object that triggered the event.</param>
		/// <param name="e">An <see cref="EventArgs"/> describing the event arguments.</param>
		private void butNext_Click(object sender, EventArgs e)
		{
			StepForward();
		}

		/// <summary>
		/// Handles the <see cref="Control.Click"/> event of the back button.
		/// </summary>
		/// <param name="sender">The object that triggered the event.</param>
		/// <param name="e">An <see cref="EventArgs"/> describing the event arguments.</param>
		private void butBack_Click(object sender, EventArgs e)
		{
			StepBack();
		}

		/// <summary>
		/// Handles the <see cref="OptionFormStep.ItemChecked"/> event of the option form steps.
		/// </summary>
		/// <remarks>
		/// This updates the back/next button states.
		/// </remarks>
		/// <param name="sender">The object that triggered the event.</param>
		/// <param name="e">An <see cref="EventArgs"/> describing the event arguments.</param>
		private void ofsStep_ItemChecked(object sender, EventArgs e)
		{
			SetWizardButtonStates();
		}

		#endregion

		#endregion
	}
}
