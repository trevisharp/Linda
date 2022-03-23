using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using Linda.Languages;

public class MainForm : Form
{
    public MainForm()
    {
        Language.Set(Language.Portuguese);

        this.FormBorderStyle = FormBorderStyle.None;
        this.WindowState = FormWindowState.Maximized;
        this.Text = "Linda";

        this.BackColor = Color.FromArgb(20, 20, 45);

        MenuStrip ms = new MenuStrip();
        ms.BackColor = Color.FromArgb(20, 20, 45);
        ms.ForeColor = Color.White;
        this.MainMenuStrip = ms;
        this.Controls.Add(ms);
        
        Language.AddTranslation(lg =>
        {
            ms.Items.Clear();

            var langbutton = new ToolStripDropDownButton();
            langbutton.Text = lg.Translate("Languages");
            langbutton.DropDown.Items.Add(lg.Translate("Portuguese"), null, (o, e) =>
            {
                Language.Set(Language.Portuguese);
            });
            ms.Items.Add(langbutton);

            ms.Items.Add(lg.Translate("Exit"), null, (o, e) =>
            {
                Application.Exit();
            });
        });

        var pb = new PictureBox();
        pb.Dock = DockStyle.Fill;
        this.Controls.Add(pb);

        Bitmap bmp = null;
        Graphics g = null;
        Timer tm = new Timer();
        tm.Interval = 20;
        tm.Tick += delegate
        {
            tick();
        };

        Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pb.Image = bmp;
            tm.Start();
        };

    }

    void tick()
    {

    }
}