using BookLib;
using BookLib.Model;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace ProjectOOP.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDataService, ItemCollection>();
            SimpleIoc.Default.Register<IDataBook, ItemCollectionBook>();
            SimpleIoc.Default.Register<IDataJournal, ItemCollectionJournal>();

            SimpleIoc.Default.Register<DataView>();
            SimpleIoc.Default.Register<DataControlViewModel>();
            SimpleIoc.Default.Register<DataResultView>();
        }

        public DataView dataView => ServiceLocator.Current.GetInstance<DataView>();
        public DataControlViewModel dataControlView => ServiceLocator.Current.GetInstance<DataControlViewModel>();
        public DataResultView resultView => ServiceLocator.Current.GetInstance<DataResultView>();

    }
}