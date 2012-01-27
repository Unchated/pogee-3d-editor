﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using ApplicationCore.ViewModels.Editors;
using ApplicationCore.DataServices;

namespace SpawnsPlugin
{
    public abstract class SpawnsViewModelBase : EditorViewModelBase, ISpawnsViewModel
    {
        public SpawnsViewModelBase(SpawnDataService service)
        {
            _service = service;
            _service.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_service_PropertyChanged);
        }

        void _service_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedSpawn":
                    NotifyPropertyChanged("SelectedSpawn");
                    break;
                case "ZoneSpawns":
                    NotifyPropertyChanged("Spawns");
                    break;

                case "Zone":
                    NotifyPropertyChanged("Zone");
                    break;

                default:
                    break;
            }
        }

        abstract public override void User3DClickAt(object sender, World3DClickEventArgs e);

        public override IDataService Service
        {
            get { return _service; }
        }

        private readonly SpawnDataService _service = null;
        public SpawnDataService SpawnsService
        {
            get { return _service; }
        }

        public ObservableCollection<EQEmu.Spawns.Spawn2> Spawns
        {
            get
            {
                if (_service != null && _service.ZoneSpawns != null)
                {
                    return _service.ZoneSpawns.Spawns;
                }
                else return null;
            }
        }

        public string Zone
        {
            get
            {
                if (_service != null)
                {
                    return _service.Zone;
                }
                return "";
            }
            set
            {
                if (_service != null)
                {
                    _service.Zone = value;
                }
                NotifyPropertyChanged("Zone");
            }
        }


        abstract public EQEmu.Spawns.Spawn2 SelectedSpawn { get; set; }


        abstract public void CreateNewSpawn(System.Windows.Media.Media3D.Point3D p);

        abstract public IEnumerable<EQEmu.Spawns.Spawn2> SelectedSpawns { get; set; }
    }
}