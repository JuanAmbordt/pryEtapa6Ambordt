using System;
using System.Drawing;
using System.Windows.Forms;

namespace pryEtapa6Ambordt
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            
            PictureBox picBox = CrearPictureBoxAleatorio();

            
            Controls.Add(picBox);

            
            MoverImagen(picBox);
        }

        private PictureBox CrearPictureBoxAleatorio()
        {
            
            PictureBox picBox = new PictureBox();
            picBox.Size = new Size(50, 50); // Tamaño predeterminado
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;

            
            string[] tiposVehiculo = { "Auto", "Avion", "Barco" };
            string tipoVehiculo = tiposVehiculo[rnd.Next(tiposVehiculo.Length)];
            Image imagen = ObtenerImagen(tipoVehiculo);

            picBox.Image = imagen;

            
            picBox.Location = new Point(rnd.Next(ClientSize.Width - picBox.Width), rnd.Next(ClientSize.Height - picBox.Height));

            return picBox;
        }

        private Image ObtenerImagen(string tipoVehiculo)
        {
            
            string nombreImagen = tipoVehiculo.ToLower(); 
            return Properties.Resources.ResourceManager.GetObject(nombreImagen) as Image;
        }

        private void MoverImagen(PictureBox picBox)
        {
            
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; // 
            timer.Tick += (sender, e) =>
            {
                
                int dx = rnd.Next(-10, 11); 
                int dy = rnd.Next(-10, 11); 

                
                int newX = picBox.Location.X + dx;
                int newY = picBox.Location.Y + dy;

                
                if (newX >= 0 && newX <= ClientSize.Width - picBox.Width && newY >= 0 && newY <= ClientSize.Height - picBox.Height)
                {
                    
                    foreach (Control control in Controls)
                    {
                        if (control != picBox && control is PictureBox && picBox.Bounds.IntersectsWith(control.Bounds))
                        {
                           
                            Controls.Remove(control);
                            control.Dispose();
                            return; 
                        }
                    }

                    
                    picBox.Location = new Point(newX, newY);
                }
            };
            timer.Start();
        }
    }
}
