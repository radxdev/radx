﻿using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Controls;
using Xcl.Forms;
using Xcl.Samples;

namespace MenuForm
{
	public class TMenuForm: TForm
	{
		public TButton btnButtons;
		public TButton btnFontSizes;
		public TButton btnLabelTest;
		public TButton btnEditSamples;
		public TButton btnTouchSamples;
		public TButton btnAlignSamples;

		public TMenuForm (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			btnButtons = TButton.Create (self);
			btnButtons.Parent = self;

			btnButtons.Top = 20;
			btnButtons.Left = 10;
			btnButtons.Height = 50;
			btnButtons.Width = Screen.Width - 20;
			btnButtons.Caption = "Buttons";
			btnButtons.OnClick += Button1Click;

			btnFontSizes = TButton.Create (self);
			btnFontSizes.Parent = self;

			btnFontSizes.Top = 80;
			btnFontSizes.Left = 10;
			btnFontSizes.Height = 50;
			btnFontSizes.Width = Screen.Width - 20;
			btnFontSizes.Caption = "Font Sizes";
			btnFontSizes.OnClick += btnFontSizesClick;

			btnLabelTest = TButton.Create (self);
			btnLabelTest.Parent = self;

			btnLabelTest.Top = 150;
			btnLabelTest.Left = 10;
			btnLabelTest.Height = 50;
			btnLabelTest.Width = Screen.Width - 20;
			btnLabelTest.Caption = "Label Test";
			btnLabelTest.OnClick += btnLabelTestClick;

			btnEditSamples = TButton.Create (self);
			btnEditSamples.Parent = self;

			btnEditSamples.Top = 220;
			btnEditSamples.Left = 10;
			btnEditSamples.Height = 50;
			btnEditSamples.Width = Screen.Width - 20;
			btnEditSamples.Caption = "Edit Test";
			btnEditSamples.OnClick +=  btnEditSamplesClick;

			btnTouchSamples = TButton.Create (self);
			btnTouchSamples.Parent = self;

			btnTouchSamples.Top = 290;
			btnTouchSamples.Left = 10;
			btnTouchSamples.Height = 50;
			btnTouchSamples.Width = Screen.Width - 20;
			btnTouchSamples.Caption = "Touch Test";
			btnTouchSamples.OnClick +=  btnTouchSamplesClick;

			btnAlignSamples = TButton.Create (self);
			btnAlignSamples.Parent = self;

			btnAlignSamples.Top = 360;
			btnAlignSamples.Left = 10;
			btnAlignSamples.Height = 50;
			btnAlignSamples.Width = Screen.Width - 20;
			btnAlignSamples.Caption = "Align Test";
			btnAlignSamples.OnClick +=  btnAlignSamplesClick;

		}

		void btnAlignSamplesClick (object sender, EventArgs e)
		{
			App.AlignSamples.Show ();
		}


		void btnTouchSamplesClick (object sender, EventArgs e)
		{
			App.TouchSamples.Show ();
		}

		void btnEditSamplesClick (object sender, EventArgs e)
		{
			App.EditSamples.Show ();
		}

		void btnLabelTestClick (object sender, EventArgs e)
		{
			App.LabelSamples.Show ();
		}

		void btnFontSizesClick (object sender, EventArgs e)
		{
			App.FontSizeSamples.Show ();	
		}

		void Button1Click (object sender, EventArgs e)
		{
			App.ButtonSamples.Show ();
			
		}
	}
}
