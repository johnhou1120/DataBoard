using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace CustomControls
{
    public class PanelEx:System.Windows.Forms.Panel
    {
        private Color _BorderColor = Color.Black;

        [Browsable(true), Description("邊框顏色"), Category("自定義分組")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
            _BorderColor = value;
            this.Invalidate();
            }
        }
 
        private int _BorderSize = 3;
 
        [Browsable(true), Description("邊框粗細"), Category("自定義分組")]
        public int BorderSize
        {
            get { return _BorderSize; }
            set 
            { 
            _BorderSize = value;
            this.Invalidate();
            }
        }

        /// <summary>
        /// 重寫OnPaint方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                            this.ClientRectangle,
                            this._BorderColor,
                            this._BorderSize,
                            ButtonBorderStyle.Solid,
                            this._BorderColor,
                            this._BorderSize,
                            ButtonBorderStyle.Solid,
                            this._BorderColor,
                            this._BorderSize,
                            ButtonBorderStyle.Solid,
                            this._BorderColor,
                            this._BorderSize,
                            ButtonBorderStyle.Solid);
        }
    }
}
