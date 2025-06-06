﻿using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualStudio2012Style
{
    public partial class FrmCopyFormater : Form
    {

        private HexBox _hexBox { get; set; }

        private string _layoutCode = @"
   /// <summary>
   /// Generated By PacketViewer ;)
   /// </summary>
   {code}";

        public FrmCopyFormater(HexBox hexBox)
        {
            InitializeComponent();

            _hexBox = hexBox;

            hex.ByteProvider = _hexBox.ByteProvider;

            btn_ToCsharp.PerformClick();
        }

        private void btn_ToCsharp_Click(object sender, EventArgs e)
        {
            var buffer = ((DynamicByteProvider)hex.ByteProvider).Bytes.ToArray();

            var generated = "var result = new byte[]{ " + HexStringToCSharp(buffer) + " }";

            txtCode.Text = _layoutCode.Replace("{code}", generated);

            SetClipBoard();
        }

        private void btn_ToByteWithoutSpace_Click(object sender, EventArgs e)
        {
            var buffer = ((DynamicByteProvider)hex.ByteProvider).Bytes.ToArray();

            var generated = BitConverter.ToString(buffer).Replace("-", "");

            txtCode.Text = _layoutCode.Replace("{code}", generated);

            SetClipBoard();
        }

        private void btn_ToByteWithSpace_Click(object sender, EventArgs e)
        {
            var buffer = ((DynamicByteProvider)hex.ByteProvider).Bytes.ToArray();

            var generated = BitConverter.ToString(buffer).Replace("-", " ");

            txtCode.Text = _layoutCode.Replace("{code}", generated);

            SetClipBoard();
        }


        private string HexStringToCSharp(byte[] buffer)
        {
            string mensagem = BitConverter.ToString(buffer).Replace("-", "");

            string[] split = (from Match m in Regex.Matches(mensagem, "..") select m.Value).ToArray();

            var sbResult = new StringBuilder();

            for (int i = 0; i < split.Length; i++)
            {
                sbResult.Append("0x" + split[i]);

                if (i + 1 < split.Length)
                    sbResult.Append(", ");
            }

            return sbResult.ToString();
        }


        private void SetClipBoard()
        {
            Clipboard.SetText(txtCode.Text);
        }
    }
}
