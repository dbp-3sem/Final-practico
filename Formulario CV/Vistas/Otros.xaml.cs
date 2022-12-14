using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Formulario_CV.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Otros : ContentPage
    {

        String names;
        String edads;
        String correos;
        String telefonos;
        String ocupacions;
        String direcions;
        String info_perfils;
        String info_idiomas;
        bool Validacion;
        int llenado;

        public Otros(String name, String edad,
            String correo, String telefono, String ocupacion,
            String direcion, String info_perfil, String idiomas)
        {
            InitializeComponent();
            names = name;
            edads = edad;
            correos = correo;
            telefonos = telefono;
            ocupacions = ocupacion;
            direcions = direcion;
            info_perfils = info_perfil;
            info_idiomas = idiomas;

        }

        string redesxy;
        string educacionxy;
        string experienciaxy;
        string hobbiesxy;

        private async void btncompletado_Clicked(object sender, EventArgs e)
        {

            redesxy = redesx.Text;
            educacionxy = educacionx.Text;
            experienciaxy = experienciax.Text;
            hobbiesxy = hobbiesx.Text;

            Validacion = Validar();

            if (Validacion == true)
            {
                await Navigation.PushAsync(new Enviar(names, edads,
                correos, telefonos, ocupacions,
                direcions, info_perfils, info_idiomas, redesxy, educacionxy,
                experienciaxy, hobbiesxy));
            }

        }


        private async void btncompletado2_Clicked(object sender, EventArgs e)
        {
            var curriculum = new EmailMessage("","","");
            curriculum.BodyFormat = EmailBodyFormat.Html;
            await Email.ComposeAsync(curriculum);
        }

        private int LLenado()
        {
                int contador = 0;

                if (!string.IsNullOrEmpty(redesxy))
                {
                    contador++;
                }
                if (!string.IsNullOrEmpty(educacionxy))
                {
                    contador++;
                }
                if (!string.IsNullOrEmpty(experienciaxy))
                {
                    contador++;
                }
                if (!string.IsNullOrEmpty(hobbiesxy))
                {
                    contador++;
                }

                return contador;
        }


        private bool Validar()
        {

                llenado = LLenado();

                if (llenado == 4)
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