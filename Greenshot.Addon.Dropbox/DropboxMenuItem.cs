﻿using System.ComponentModel.Composition;
using Dapplo.CaliburnMicro.Extensions;
using Dapplo.CaliburnMicro.Menu;
using Greenshot.Addon.Dropbox.Forms;
using MahApps.Metro.IconPacks;

namespace Greenshot.Addon.Dropbox
{
	/// <summary>
	/// This will add an extry for the exit to the context menu
	/// </summary>
	[Export("systray", typeof(IMenuItem))]
	public sealed class DropboxMenuItem : MenuItem
	{
		[Import]
		private IDropboxLanguage DropboxLanguage
		{
			get;
			set;
		}

		[Import]
		private IDropboxConfiguration DropboxConfiguration
		{
			get;
			set;
		}

		public override void Initialize()
		{
			Id = "Dropbox";
			// automatically update the DisplayName

			DropboxLanguage.CreateBinding(this, nameof(IDropboxLanguage.SettingsTitle));
			Icon = new PackIconMaterial
			{
				Kind = PackIconMaterialKind.Dropbox
			};
		}

		public override void Click(IMenuItem clickedItem)
		{
			new SettingsForm().ShowDialog();
		}
	}
}