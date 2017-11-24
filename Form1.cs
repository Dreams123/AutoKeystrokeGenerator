// Decompiled with JetBrains decompiler
// Type: WindowsFormsApplication1.Form1
// Assembly: WindowsFormsApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F4330250-3F4C-4B28-85AA-4AD69C328D79
// Assembly location: C:\WindowsFormsApplication1.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public class Form1 : Form
  {
    private IContainer components = (IContainer) null;
    private const int MOUSEEVENTF_MOVE = 1;
    private const int MOUSEEVENTF_LEFTDOWN = 2;
    private const int MOUSEEVENTF_LEFTUP = 4;
    private const int MOUSEEVENTF_RIGHTDOWN = 8;
    private const int RIGHTDOWN = 8;
    private const int RIGHTUP = 16;
    private const int LEFTDOWN = 2;
    private const int LEFTUP = 4;
    private const int MIDDLEDOWN = 32;
    private const int MIDDLEUP = 64;
    private const int MOVE = 1;
    private const int ABSOLUTE = 32768;
    private const string DOWN = "{DOWN}";
    private const string UP = "{UP}";
    private const string SWITCH = "^TAB";
    private Button button1;

    public Form1()
    {
      this.InitializeComponent();
    }

    private static void PressKey(int count, string key)
    {
      for (int index = 0; index < count; ++index)
      {
        SendKeys.SendWait(key);
        Thread.Sleep(count * 15);
      }
    }

    private static void PressMouse(int no)
    {
      for (int index = 0; index < no; ++index)
      {
        Form1.mouse_event(32, 0, 0, 0, 0);
        Form1.mouse_event(64, 0, 0, 0, 0);
      }
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

    private void Form1_Load(object sender, EventArgs e)
    {
      this.Visible = false;
      Random random = new Random();
      while (true)
      {
        SendKeys.SendWait("^{TAB}");
        Thread.Sleep(1500);
        int count = random.Next(12, 100);
        Form1.PressKey(count, "{DOWN}");
        Form1.PressKey(count, "{UP}");
        Form1.PressMouse(random.Next(2, 50));
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button1 = new Button();
      this.SuspendLayout();
      this.button1.Location = new Point(91, 104);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 261);
      this.Controls.Add((Control) this.button1);
      this.Name = nameof (Form1);
      this.Text = nameof (Form1);
      this.Load += new EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
    }
  }
}
