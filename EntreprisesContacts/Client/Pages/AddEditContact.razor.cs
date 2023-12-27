using Blazored.Toast.Services;
using EntreprisesContacts.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Notifications;
using System.Net.Http.Json;


namespace EntreprisesContacts.Client.Pages
{
    public class AddEditContactBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        [Parameter]
        public int contID { get; set; }

        protected string Title = "Add";
        public Contact cont = new();
        protected List<Entreprise> entrepriseList = new();


        

        protected override async Task OnInitializedAsync()
        {
            await GetEntrepriseList();
        }


        protected override async Task OnParametersSetAsync()
        {
            if (contID != 0)
            {
                Title = "Edit";
                cont = await Http.GetFromJsonAsync<Contact>("api/Contact/" + contID);
            }
        }

        protected async Task GetEntrepriseList()
        {
            entrepriseList = await Http.GetFromJsonAsync<List<Entreprise>>("api/Contact/GetEntrepriseList");
        }

        protected async Task SaveContact()
        {
            if (cont.ContactId != 0)
            {
                await Http.PutAsJsonAsync("api/Contact", cont);
            }
            else
            {
                await Http.PostAsJsonAsync("api/Contact", cont);
                toastService.ShowSuccess("Contact added successfully");
            }
            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/contactlist");
        }
    }
}
