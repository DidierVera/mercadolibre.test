using System;
namespace Mercadolibre.test.Logic.Contract.Presenters
{
    public interface IGenericView
    {
        void UpdateView(object model);
        void ShowAlert(string message);
    }
}
