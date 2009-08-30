// <autogenerated>
//   This file was generated by T4 code generator DataClasses1.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

namespace Simple.Generator
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;

    [Table(Name = "dbo.EmployeeTerritories")]
    public partial class EmployeeTerritory : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int employeeID;
        private string territoryID;
        private EntityRef<Employee> employee;
        private EntityRef<Territory> territory;
        
        public EmployeeTerritory()
        {
            this.employee = default(EntityRef<Employee>);
            this.territory = default(EntityRef<Territory>);
            this.OnCreated();
        }
        
        public event PropertyChangingEventHandler PropertyChanging;
        
        public event PropertyChangedEventHandler PropertyChanged;

        [Column(Name = "EmployeeID", Storage = "employeeID", CanBeNull = false, DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int EmployeeID
        {
            get
            {
                return this.employeeID;
            }
        
            set
            {
                if (this.employeeID != value)
                {
                    if (this.employee.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEmployeeIDChanging(value);
                    this.SendPropertyChanging("EmployeeID");
                    this.employeeID = value;
                    this.SendPropertyChanged("EmployeeID");
                    this.OnEmployeeIDChanged();
                }
            }
        }

        [Column(Name = "TerritoryID", Storage = "territoryID", CanBeNull = false, DbType = "NVarChar(20) NOT NULL", IsPrimaryKey = true)]
        public string TerritoryID
        {
            get
            {
                return this.territoryID;
            }
        
            set
            {
                if (this.territoryID != value)
                {
                    if (this.territory.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTerritoryIDChanging(value);
                    this.SendPropertyChanging("TerritoryID");
                    this.territoryID = value;
                    this.SendPropertyChanged("TerritoryID");
                    this.OnTerritoryIDChanged();
                }
            }
        }

        [Association(Name = "Employee_EmployeeTerritory", Storage = "employee", ThisKey = "EmployeeID", OtherKey = "EmployeeID", IsForeignKey = true)]
        public Employee Employee
        {
            get
            {
                return this.employee.Entity;
            }
        
            set
            {
                Employee previousValue = this.employee.Entity;
                if (previousValue != value || !this.employee.HasLoadedOrAssignedValue)
                {
                    this.SendPropertyChanging("Employee");
        
                    if (previousValue != null)
                    {
                        this.employee.Entity = null;
                        previousValue.EmployeeTerritories.Remove(this);
                    }
        
                    this.employee.Entity = value;
        
                    if (value != null)
                    {
                        value.EmployeeTerritories.Add(this);
                        this.employeeID = value.EmployeeID;
                    }
                    else
                    {
                        this.employeeID = default(int);
                    }
        
                    this.SendPropertyChanged("Employee");
                }
            }
        }

        [Association(Name = "Territory_EmployeeTerritory", Storage = "territory", ThisKey = "TerritoryID", OtherKey = "TerritoryID", IsForeignKey = true)]
        public Territory Territory
        {
            get
            {
                return this.territory.Entity;
            }
        
            set
            {
                Territory previousValue = this.territory.Entity;
                if (previousValue != value || !this.territory.HasLoadedOrAssignedValue)
                {
                    this.SendPropertyChanging("Territory");
        
                    if (previousValue != null)
                    {
                        this.territory.Entity = null;
                        previousValue.EmployeeTerritories.Remove(this);
                    }
        
                    this.territory.Entity = value;
        
                    if (value != null)
                    {
                        value.EmployeeTerritories.Add(this);
                        this.territoryID = value.TerritoryID;
                    }
                    else
                    {
                        this.territoryID = default(string);
                    }
        
                    this.SendPropertyChanged("Territory");
                }
            }
        }
        
        protected virtual void SendPropertyChanging(string propertyName)
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
        
        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        #region Extensibility methods
        
        partial void OnCreated();
        
        partial void OnLoaded();
        
        partial void OnValidate(ChangeAction action);
        
        partial void OnEmployeeIDChanging(int value);
        
        partial void OnEmployeeIDChanged();
        
        partial void OnTerritoryIDChanging(string value);
        
        partial void OnTerritoryIDChanged();
        
        #endregion
    }
}