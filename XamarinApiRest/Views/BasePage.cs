using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace XamarinApiRest.Views
{
    public class BasePage
    {
        private IMediator _mediator;

        protected IMediator Mediator
        {
            get
            {
                if (_mediator == null)
                {
                    _mediator = App.ServiceProvider.GetRequiredService<IMediator>();
                }
                return _mediator;
            }
        }
    }
}