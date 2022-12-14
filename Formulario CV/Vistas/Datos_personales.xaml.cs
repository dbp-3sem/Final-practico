using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Formulario_CV.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Datos_personales : ContentPage
    {
        public Datos_personales()
        {
            InitializeComponent();
        }

        string Info_nombre;
        string Info_edad;
        string Info_correo;
        string Info_telefono;
        string Info_ocupacion;
        string Info_direccion;
        bool Validacion;
        int llenado;

        

        private async void btncompletado_Clicked(object sender, EventArgs e)
        {
            Info_nombre = info_nombre.Text;
            Info_edad = info_edad.Text;
            Info_correo = info_correo.Text;
            Info_telefono = info_telefono.Text;
            Info_ocupacion = info_ocupacion.Text;
            Info_direccion = info_direccion.Text;

            Validacion = Validar();

            if (Validacion == true)
            {
                await Navigation.PushAsync(new Perfil(Info_nombre,
                Info_edad, Info_correo, Info_telefono, Info_ocupacion,
                Info_direccion));
            }
        }


        private int LLenado()
        {
            int contador = 0;

            if (!string.IsNullOrEmpty(info_nombre.Text))
            {
                contador++;
            }
            if (!string.IsNullOrEmpty(info_edad.Text))
            {
                contador++;
            }
            if (!string.IsNullOrEmpty(info_correo.Text))
            {
                contador++;
            }
            if (!string.IsNullOrEmpty(info_telefono.Text))
            {
                contador++;
            }
            if (!string.IsNullOrEmpty(info_ocupacion.Text))
            {
                contador++;
            }
            if (!string.IsNullOrEmpty(info_direccion.Text))
            {
                contador++;
            }
            return contador;
        }


        private bool Validar()
        {

            llenado = LLenado();

            if (llenado == 6)
            {
                return true;
            }
            else
            {
                DisplayAlert("Error", "LLene todos los datos, por favor", "Ok");
                return false;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var entry = new Entry()
            {
                Placeholder = "Introduce tu ocupación"

            };
            //ocupacion.Children.Add(entry);

        }
    }

}