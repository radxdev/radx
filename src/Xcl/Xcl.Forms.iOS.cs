﻿/**
*  This file is part of the RadX project
*
*  Copyright (c) 2016 radx.plugin@gmail.com
*
*  Checkout AUTHORS file for more information on the developers
*
*  This library is free software; you can redistribute it and/or
*  modify it under the terms of the GNU Lesser General Public
*  License as published by the Free Software Foundation; either
*  version 2.1 of the License, or (at your option) any later version.
*
*  This library is distributed in the hope that it will be useful,
*  but WITHOUT ANY WARRANTY; without even the implied warranty of
*  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
*  Lesser General Public License for more details.
*
*  You should have received a copy of the GNU Lesser General Public
*  License along with this library; if not, write to the Free Software
*  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307
*  USA
*/
using System;
using System.Base;
using System.Classes;
using Xcl.Controls;
using Xcl.StdCtrls;
using Xcl.Forms;
#if __IOS__
using UIKit;
using System.Drawing;
using CoreGraphics;
#endif

namespace Xcl.Forms
{
	#if __IOS__
	public partial class TApplication:TComponent
	{
		public static UIViewController LastViewController=null;
		public static UIWindow Window=null;

		partial void NativeInitialize(object param)
		{
			Window = new UIWindow(UIScreen.MainScreen.Bounds);
		}

		partial void NativeRun()
		{
			TApplication.LastViewController = _.Application.MainForm.handle;
			Window.RootViewController = TApplication.LastViewController;
			Window.MakeKeyAndVisible();
		}
	}


	public partial class TScreen:TComponent
	{
		partial void NativeGetWidth()
		{
			//TODO: Use nfloat everywhere
			FWidth=(float)UIScreen.MainScreen.Bounds.Width;			
		}

		partial void NativeGetHeight()
		{
			//TODO: Use nfloat everywhere
			FHeight=(float)UIScreen.MainScreen.Bounds.Height;			
		}

	}

	public class FormViewController: UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;
		}	

		public override bool PrefersStatusBarHidden()
		{
			return(true);
		}
	}

	public partial class TCustomForm: TScrollingControl
	{
		public FormViewController handle;

		protected override void CreateHandle()
		{
			handle = new FormViewController ();
			Handle = handle.View;
		}


		public override void NativeSetParent(TControl AControl)
		{
			handle.View.AddSubview (AControl.Handle as UIView);
		}

			
		public override void UpdateBounds()
		{

		}
	}

	public partial class TForm:TCustomForm
	{
		public UIViewController ParentViewController = null;

		public override void Close()
		{
			TApplication.LastViewController = ParentViewController;			
			if (TApplication.LastViewController == null)
				TApplication.LastViewController = _.Application.MainForm.handle;
			handle.DismissViewController (true, null);
			ParentViewController = null;

		}

		partial void Initialize()
		{
			Loaded();
		}

		public override void Show()
		{
			if (ParentViewController == null)
				ParentViewController = TApplication.LastViewController;
			
			ParentViewController.ShowViewController (handle, null);
			TApplication.LastViewController = handle;
		}
	}
	#endif
}
