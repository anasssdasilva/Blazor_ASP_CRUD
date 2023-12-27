using Blazored.Toast.Services;
using EntreprisesContacts.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;

namespace EntreprisesContacts.Client.Pages
{
    public class AddEditEntrepriseBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        [Parameter]
        public int entID { get; set; }

        protected string Title = "Add";
        public Entreprise ent = new();

        protected async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            IBrowserFile imgFile = e.File;
            var buffers = new byte[imgFile.Size];
            await imgFile.OpenReadStream().ReadAsync(buffers);
            string imageType = imgFile.ContentType;
            ent.thumbnail = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
        }


        protected override async Task OnParametersSetAsync()
        {
            if (entID != 0)
            {
                Title = "Edit";
                ent = await Http.GetFromJsonAsync<Entreprise>("api/Entreprise/" + entID);
            }
        }


        protected async Task SaveEntreprise()
        {
            if (ent.EntrepriseId != 0)
            {
                await Http.PutAsJsonAsync("api/Entreprise", ent);
            }
            else
            {
                await Http.PostAsJsonAsync("api/Entreprise", ent);
                toastService.ShowSuccess("Entreprise added successfully");
            }
            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/entrepriselist");
        }
    }
}
