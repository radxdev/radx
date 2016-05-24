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
using System.Collections.Generic;
using System.Base;
using System.SysUtils;
using System.Classes;
using System.UITypes;
using Xcl.ImgList;
using Xcl.Graphics;
using System.Linq;

namespace Xcl.Controls
{
	public class TMouseEventArgs:EventArgs
	{
		public TMouseEventArgs(TMouseButton Button, TShiftState Shift, float X, float Y)
		{
			this.Button=Button;
			this.Shift=Shift;
			this.X = X;
			this.Y = Y;
		}

		public TMouseButton Button;
		public TShiftState Shift;
		public float X;
		public float Y;
	}
	public delegate void TMouseEvent(object sender, TMouseEventArgs e);
	public delegate void TNotifyEvent(object sender, EventArgs e);


	//TODO: Review the usage of this enum and convert it to a TSet

	/// <summary>
	/// Control State
	/// </summary>
	public enum TControlState {csLButtonDown=1, csClicked=2, csPalette=4,
		csReadingState=8, csAlignmentNeeded=16, csFocusing=32, csCreating=64,
		csPaintCopy=128, csCustomPaint=256, csDestroyingHandle=512, csDocking=1024,
		csDesignerHide=2048, csPanning=4096, csRecreating=8192, csAligning=16384, csGlassPaint=32768,
		csPrintClient=65536};

	/// <summary>
	/// Set for control styles
	/// </summary>
	public class TControlStyle:TSet
	{
		public TControlStyle(int initialvalue):base(initialvalue)
		{
		}		
		public static int csAcceptsControls=1;
		public static int csCaptureMouse = 2;
		public static int csDesignInteractive = 4;
		public static int csClickEvents = 8;
		public static int csFramed = 16;
		public static int csSetCaption = 32;
		public static int csOpaque = 64;
		public static int csDoubleClicks = 128;
		public static int csFixedWidth = 256;
		public static int csFixedHeight = 512;
		public static int csNoDesignVisible = 1024;
		public static int csReplicatable = 2048;
		public static int csNoStdEvents = 4096;
		public static int csDisplayDragImage = 8192;
		public static int csReflector = 16384;
		public static int csActionClient = 32768;
		public static int csMenuEvents = 65536;
		public static int csNeedsBorderPaint = 131072;
		public static int csParentBackground = 262144;
		public static int csPannable = 524288;
		public static int csAlignWithMargins = 1048576;
		public static int csGestures = 2097152;
		public static int csPaintBlackOpaqueOnGlass = 4194304;
		public static int csOverrideStylePaint=8388608;		
	}

	//TODO: Implement the Margins property
	/// <summary>
	/// Used for the Margins property
	/// </summary>
	public class TMargins:TPersistent
	{
		private TControl FControl;

		private float FLeft;
		private float FTop;
		private float FRight;
		private float FBottom;

		protected TControl Control {get {return FControl; }}

		/// <summary>
		/// Initializes a new instance of the <see cref="Xcl.Controls.TMargins"/> class to be used in a Control
		/// </summary>
		/// <param name="Control">Control.</param>
		public TMargins(TControl Control)
		{
			FControl = Control;
			InitDefaults (this);
		}

		/// <summary>
		/// Sets the control bounds.
		/// </summary>
		/// <param name="ALeft">A left.</param>
		/// <param name="ATop">A top.</param>
		/// <param name="AWidth">A width.</param>
		/// <param name="AHeight">A height.</param>
		/// <param name="Aligning">If set to <c>true</c> aligning.</param>
		public void SetControlBounds(float ALeft, float ATop, float AWidth, float AHeight, bool Aligning = false)
		{
			if (Control != null) {
				if (Aligning) {
					Control.AnchorMove = true;
					Control.ControlState = Control.ControlState | TControlState.csAligning;
				}
			}
			try
			{
				if ((Control.AlignWithMargins) && (Control.Parent!=null))
				{
					Control.SetBounds(ALeft+FLeft, ATop+FTop, AWidth - (FLeft+FRight), AHeight - (FTop+FBottom));
				}
				else
				{
					Control.SetBounds(ALeft, ATop, AWidth, AHeight);
				}
			}
			finally {
				if (Aligning) {
					Control.AnchorMove = false;
					Control.ControlState = Control.ControlState & TControlState.csAligning;
				}
			}
		}

		/// <summary>
		/// Initializes the default values
		/// </summary>
		/// <param name="Margins">Margins.</param>
		public static void InitDefaults (TMargins Margins)
		{
			Margins.FLeft = 3;
			Margins.FRight = 3;
			Margins.FTop = 3;
			Margins.FBottom = 3;
		}

	}


	public enum TScalingFlags {sfLeft=1, sfTop=2, sfWidth=4, sfHeight=8, sfFont=16, sfDesignSize=32};
	public enum THelpType {htKeyword=1, htContext=2};


}
