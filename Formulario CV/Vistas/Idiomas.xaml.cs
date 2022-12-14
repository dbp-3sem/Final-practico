using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Formulario_CV.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Idiomas : ContentPage
    {

        String names;
        String edads;
        String correos;
        String telefonos;
        String ocupacions;
        String direcions;
        String info_perfils;
        bool validacion;

        public Idiomas(String name, String edad,
            String correo, String telefono, String ocupacion,
            String direcion, String info_perfil)
        {
            InitializeComponent();
            names = name;
            edads = edad;
            correos = correo;
            telefonos = telefono;
            ocupacions = ocupacion;
            direcions = direcion;
            info_perfils = info_perfil;

        }

        string idiomasxy;

        private async void btncompletado_Clicked(object sender, EventArgs e)
        {

            idiomasxy = idiomasx.Text;

            validacion = Validar();

            if (validacion == true)
            {

                await Navigation.PushAsync(new Otros(names, edads,
                correos, telefonos, ocupacions,
                direcions, info_perfils, idiomasxy));

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var entry = new Entry()
            {
                Placeholder = "Introduce otro idioma"

            };
            languague.Children.Add(entry);
        }

        private bool Validar()
        {
            if (!string.IsNullOrEmpty(idiomasxy))
            {
                return true;
            }
            else
            {
                DisplayAlert("Error", "LLene todos los datos, por favor", "Ok");
                return false;
            }
        }
    }


}