using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using TreeAwarenessFirebase.Services;
using TreeAwarenessFirebase.Model;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using System.Linq;

namespace TreeAwarenessFirebase.ViewModel
{
    public class TreesViewModel : BaseViewModel
    {
        public int TreeCode { get; set; }
        public string Name { get; set; }
        public string InitialIdentification { get; set; }
        public string Notes { get; set; }
        public string GPSCoordinates { get; set; }
        public string Location { get; set; }
        public string Landmark { get; set; }
        public string Height { get; set; }
        public string Canopy { get; set; }

        private DBFirebase services;

      

        public Command AddTreeCommand { get; }
        public ObservableCollection<TreeInfo> _trees = new ObservableCollection<TreeInfo>();
        public ObservableCollection<TreeInfo> Trees
        {
            get { return _trees; }
            set
            {
                _trees = value;
                OnPropertyChanged();
            }
        }

        public TreesViewModel()
        {
            services = new DBFirebase();
            Trees = services.getTree();
            AddTreeCommand = new Command(async () => await addTreeAsync(TreeCode, Name, InitialIdentification,
                Notes, GPSCoordinates, Location, Landmark, Height, Canopy));

        

        }
        public async Task addTreeAsync(int TreeCode, string Name,string InitialIdentification,string Notes, string GPSCoordinates, 
            string Location, string Landmark, string Height, string Canopy)
        {
            await services.AddTree(TreeCode, Name, InitialIdentification, Notes, GPSCoordinates, Location, Landmark, Height, Canopy);
        }

       


    }
}
















        //private Services.DatabaseContext getContext()
        //{
        //    return new Services.DatabaseContext();
        //}

        //public async Task<List<TreeInfo>> GetAllTrees()
        //{
        //    var _dbContext = getContext();
        //    var res = await _dbContext.Trees.ToListAsync();
        //    return res;

        //}
        //public async Task<int> UpdateTrees(TreeInfo obj)
        //{
        //    var _dbContext = getContext();
        //    _dbContext.Trees.Update(obj);
        //    int c = await _dbContext.SaveChangesAsync();
        //    return c;
        //}

        //public int InsertTree(TreeInfo obj)
        //{
        //    var _dbContext = getContext();
        //    _dbContext.Trees.Add(obj);
        //    int c = _dbContext.SaveChanges();
        //    return c;
        //}

        //public int DeleteTree(TreeInfo obj)
        //{
        //    var _dbContext = getContext();
        //    _dbContext.Trees.Remove(obj);
        //    int c = _dbContext.SaveChanges();
        //    return c;
        //}

