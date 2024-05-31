using Application.Abstractions.Pages;
using Domain.Guards;
using Presentation.ViewModels;

namespace Presentation.Views
{
    public partial class PondsPage : ContentPage, IGuardedEntity
    {

        public PondsPage(PondViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        public IEnumerable<Guard> Guards => [Guard.LoginRequired];
    }
}