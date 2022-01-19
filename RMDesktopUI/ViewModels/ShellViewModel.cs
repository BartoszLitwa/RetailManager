using Caliburn.Micro;
using RMDesktopUI.EventModels;
using RMDesktopUI.ViewModels.UserControls;
using System.Threading;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;

        public ShellViewModel(LoginViewModel loginVM, IEventAggregator events, SalesViewModel salesVM)
        {
            _events = events;
            _salesVM = salesVM;

            // Subscribe for every fired event
            _events.SubscribeOnUIThread(this);

            // Override current viewModel - new Instance
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

        // LogOnEvent
        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVM);
        }
    }
}
