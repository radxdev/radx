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
#if __ANDROID__
using Android.Widget;
using Java.IO;
using Android.Graphics;
using Android.Views;
using Android.Text;
#endif

namespace Xcl.StdCtrls
{
	#if __ANDROID__
	public partial class TButton: TCustomButton
	{
		public Button button;

		protected override void NativeOnClickAdd(EventHandler value)
		{
			button.Click+=value;
		}
		protected override void NativeOnClickRemove(EventHandler value)
		{
			button.Click-=value;
		}

		public override void NativeSetEnabled()
		{
			button.Enabled = Enabled;
		}



		protected override void CreateNativeHandle()
		{
			button = new Button (TApplication.context);
			button.SetAllCaps (false);
			Handle = button;
		}

		public override void NativeChanged()
		{
			NativeApplyFontChanges ();
		}


		public override void SetText(string Value)
		{
			base.SetText(Value);
			button.Text = Value;
		}
	}
		
	public partial class TEdit: TCustomEdit
	{
		public EditText edittext;

		private EventHandler FOnChanged;

		protected void OnChange(object sender, TextChangedEventArgs args)
		{
			//TODO: Review how to pass args in the right way
			FOnChanged (sender, args);
		}

		protected override void NativeOnChangeAdd(EventHandler value)
		{
			FOnChanged += value;
			edittext.TextChanged += OnChange;
		}

		protected override void NativeOnChangeRemove(EventHandler value)
		{
			FOnChanged -= value;
			edittext.TextChanged -= OnChange;
		}


		protected override void CreateNativeHandle()
		{
			edittext = new EditText (TApplication.context);
			Handle = edittext;
		}

		public override void SetText(string Value)
		{
			base.SetText(Value);
			edittext.Text = Value;

		}

		partial void NativeSetPlaceHolder(string value)
		{
			edittext.Hint = value;
		}


		public override string GetText()
		{
			return(edittext.Text);
		}

	}

	public partial class TLabel:TGraphicControl
	{
		public TextView textview;

		protected override void CreateNativeHandle()
		{
			textview = new TextView (TApplication.context);
			//FFont.handle = handle.Font;
			//handle.SetBackgroundColor(Android.Graphics.Color.Aqua);
			Handle = textview;
		}

		public override void NativeChanged()
		{
			NativeApplyFontChanges ();
		}

		private void UpdateGravity()
		{
			GravityFlags flags=GravityFlags.NoGravity;

			switch(FLayout)
			{
			case TTextLayout.tlTop:
				flags |= GravityFlags.Top;
				break;
			case TTextLayout.tlCenter:
				flags |= GravityFlags.CenterVertical;
				break;
			case TTextLayout.tlBottom:
				flags |= GravityFlags.Bottom;
				break;
			}

			switch (FAlignment)
			{
			case TAlignment.taCenter:
				flags |= GravityFlags.CenterHorizontal;
				break;
			case TAlignment.taLeftJustify:
				flags |= GravityFlags.Left;				
				break;
			case TAlignment.taRightJustify:
				flags |= GravityFlags.Right;
				break;
			default:
				flags |= GravityFlags.Left;
				break;
			}

			textview.Gravity = flags;
		}

		partial void NativeSetTextLayout()
		{
			UpdateGravity();
		}

		partial void NativeSetTextAlignment()
		{
			UpdateGravity();			
		}

		public override void SetText(string Value)
		{
			base.SetText(Value);
			textview.Text = Value;
		}
	}

	#endif
}
