using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using MyDapperDemo.Common.Interfaces;
using MyDapperDemo.Data;
using MyDapperDemo.Entities;

using Ninject;

namespace MyDapperDemo.Console
{
    class Program
    {
        #region NORTHWIND REPOSITORIES
        
        static IShipperRepository shipperRepository = null;
        static ICategoryRepository categoryRepository = null;
        static IProductRepository productRepository = null;

        static MyDapperDemo.Data.BasicRepository basicRepository = new Data.BasicRepository();
        static MyDapperDemo.Data.DynamicRepository dynamicRepository = new Data.DynamicRepository();
        #endregion

        #region MAPS REPOSITORIES
        static MyDapperDemo.Data.MAPS.OrganisationRepository organisationRepository = new Data.MAPS.OrganisationRepository();
        static MyDapperDemo.Data.MAPS.PersonRepository personRepository = new Data.MAPS.PersonRepository();
        static MyDapperDemo.Data.MAPS.TitleRepository titleRepository = new Data.MAPS.TitleRepository();
        static MyDapperDemo.Data.MAPS.GroupRepository groupRepository = new Data.MAPS.GroupRepository();
        #endregion

        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IShipperRepository>().To<Data.ShipperRepository>().WithConstructorArgument("connectionString", "DataSource=xxx");
            kernel.Bind<ICategoryRepository>().To<Data.CategoryRepository>();
            kernel.Bind<IProductRepository>().To<Data.ProductRepository>();

            //are these needed???
            /*
            kernel.Bind<IShipper>().To<Entities.Shipper>();
            kernel.Bind<ICategory>().To<Entities.Category>();    
            kernel.Bind<IProduct>().To<Entities.Product>();    
            */

            shipperRepository = kernel.Get<IShipperRepository>();
            categoryRepository = kernel.Get<ICategoryRepository>();
            productRepository = kernel.Get<IProductRepository>();
            
            System.Console.WriteLine("Connection String: {0}", shipperRepository.ToString());

            #region MAPS STUFF
            /*
            // SIMPLE QUERY
            foreach(var item in organisationRepository.GetAllOrganisations())
            {
                System.Console.WriteLine("OrgId: {0} ¦ OrgName: {1} ¦ Phone: {2}", item.OrganisationId, item.OrganisationName, item.Phone);
            }         

            // SIMPLE JOIN QUERY WITH PARAMETER
            foreach (var item in organisationRepository.GetAllOrganisationsInGroupId(474))
            {
                System.Console.WriteLine("OrgId: {0} ¦ OrgName: {1} ¦ Phone: {2}", item.OrganisationId, item.OrganisationName, item.Phone);
            }

            // SIMPLE QUERY USING EMBEDDED SQL RESOURCE
            foreach (var item in personRepository.GetAllPeople())
            {
                System.Console.WriteLine("PersonId: {0} ¦ LastName: {1} ¦ FirstName: {2} ¦ Phone: {3}", item.PersonId, item.LastName, item.FirstName, item.MobilePhone);
            }

            // SIMPLE QUERY USING STORED PROC
            foreach (var item in titleRepository.GetAllTitles())
            {
                System.Console.WriteLine("TitleId: {0} ¦ Desc: {1}", item.TitleID, item.TitleDesc);
            }

            // MULTIPLE QUERIES RESULTS
            var org = organisationRepository.GetOrganisationWithGroups(448);
            if (org != null)
            {
                System.Console.WriteLine("OrgId: {0} ¦ OrgName: {1} ¦ Phone: {2}", org.OrganisationId, org.OrganisationName, org.Phone);
                foreach (var grp in org.Groups)
                {
                    System.Console.WriteLine("GroupId: {0} ¦ Desc: {1}", grp.GroupID, grp.GroupDesc);
                }
            }

            // MULTI MAPPING QUERY WITH PARAMETER (a single row to multiple objects)
            var person = personRepository.GetPersonWithOrganisation(3348);
            if (person != null)
            {
                System.Console.WriteLine("PersonId: {0} ¦ LastName: {1} ¦ FirstName: {2}", person.PersonId, person.LastName, person.FirstName);
            }

            // INSERT ITEM QUERY
            MyDapperDemo.Entities.MAPS.Organisation newOrg = new Entities.MAPS.Organisation
            {
                OrganisationName = "Barrys Bits",
                Phone = "555 551155"
            };
            int rowsAffected = organisationRepository.AddOrganisation2(newOrg);
            System.Console.WriteLine("Rows affected: {0}", rowsAffected);
            System.Console.WriteLine("NewId: {0}", org.OrganisationId);

            foreach (var item in organisationRepository.GetAllOrganisations())
            {
                System.Console.WriteLine("OrgId: {0} ¦ OrgName: {1} ¦ Phone: {2}", item.OrganisationId, item.OrganisationName, item.Phone);
            }

            // QUERY WITH DYNAMIC RESULT
            dynamic bankaccs = organisationRepository.GetAllBankAccounts();
            foreach (var item in bankaccs)
            {
                System.Console.WriteLine("AccName: {0}", item.BankAccountName);
            }

            
            */

            /*

            MyDapperDemo.Entities.MAPS.Person p = new Entities.MAPS.Person
            {
                FirstName = "Hoof",
                LastName = "Hearted",
                MobilePhone = "021 5553332",
                DirectEmail = "Hoof.Hearted@gmail.com"
            };

            int rowsAffected = personRepository.AddPerson(p);
            System.Console.WriteLine("Rows affected: {0}", rowsAffected);
            System.Console.WriteLine("NewId: {0}", p.PersonId);

            foreach (var item in personRepository.GetAllPeople())
            {
                System.Console.WriteLine("PersonId: {0} ¦ LastName: {1} ¦ FirstName: {2}", item.PersonId, item.LastName, item.FirstName);
            }
             
              foreach (var item in groupRepository.GetAllGroups())
            {
                System.Console.WriteLine("GroupId: {0} ¦ Desc: {1}", item.GroupID, item.GroupDesc);
            }

            */
            #endregion

            PrintAllShippers(shipperRepository.GetAll());
            
            AddShipper("Barrys Bits");
            //System.Console.ReadLine();
            
            PrintAllShippers(shipperRepository.GetAll());
           
            //EditShipper(4, "Bobs Bits");
            EditShipper("Barrys Bits", "Bobs Bits");
            //System.Console.ReadLine();
            
            PrintAllShippers(shipperRepository.GetAll());

            DeleteShipper(shipperRepository.GetShipperByName("Bobs Bits").ShipperId);
            //System.Console.ReadLine();

            PrintAllShippers(shipperRepository.GetAll());
            
            System.Console.WriteLine("CATEGORIES");
            foreach (var item in categoryRepository.GetAll())
            {
                System.Console.WriteLine("CategoryId: {0} ¦ CategoryName: {1} ¦ Desc: {2} ¦ PicSize: {3}", item.CategoryId, item.CategoryName, item.Description, item.Picture.Length);
            }
            System.Console.ReadLine();

            System.Console.WriteLine("\n\nPRODUCTS");
            foreach (var item in productRepository.GetAll())
            {
                System.Console.WriteLine("ProductId: {0} ¦ SupplierId: {1} ¦ ProductName: {2}", item.ProductId, item.SupplierId, item.ProductName);
            }
            System.Console.ReadLine();

            System.Console.WriteLine("\n\nPRODUCTS WITH CATEGORIES");
            foreach (var item in productRepository.GetAllWithCategory())
            {
                System.Console.WriteLine("ProductId: {0} ¦ SupplierId: {1} ¦ ProductName: {2} ¦ CategoryName: {3}", item.ProductId, item.SupplierId, item.ProductName, item.Category.CategoryName);
            }
            System.Console.ReadLine();

            //System.Console.WriteLine("\n\nDYNAMIC");
            //foreach (var undefinedType in dynamicRepository.GetAllCategories())
            //{
            //    System.Console.WriteLine("CategoryId: {0} ¦ CategoryName: {1} ¦ Desc: {2}", undefinedType.CategoryId, undefinedType.CategoryName, undefinedType.Description);
            //}

            //System.Console.WriteLine("Number of Products: {0}", basicRepository.GetNumberOfProducts());

            //STORED PROC SUPPORT
            //TRANSACTION SUPPORT

            //EXTENSION SUPPORT FOR ASYNC METHODS
            //

            System.Console.ReadLine();
        }

        private static void AddShipper(string name)
        {
            System.Console.WriteLine("Adding : {0}", name);

            IShipper shipper = new Shipper
            {
                CompanyName = name              
            };

            int rowsAffected = shipperRepository.InsertShipper(shipper);

            System.Console.WriteLine("Rows affected: {0}", rowsAffected);
        }

        private static void EditShipper(int shipperId, string newCompanyName)
        {
            System.Console.WriteLine("Editing : {0}", shipperId);

            IShipper shipper = shipperRepository.GetShipperById(shipperId);

            if (shipper != null)
            {
                shipper.CompanyName = newCompanyName;

                int rowsAffected = shipperRepository.UpdateShipper(shipper);

                System.Console.WriteLine("Rows affected: {0}", rowsAffected);
            }
        }

        private static void EditShipper(string companyName, string newCompanyName)
        {
            System.Console.WriteLine("Editing : {0}", companyName);

            IShipper shipper = shipperRepository.GetShipperByName(companyName);

            if (shipper != null)
            {
                shipper.CompanyName = newCompanyName;

                int rowsAffected = shipperRepository.UpdateShipper(shipper);

                System.Console.WriteLine("Rows affected: {0}", rowsAffected);
            }
        }

        private static void DeleteShipper(int shipperId)
        {
            System.Console.WriteLine("Deleting : {0}", shipperId);

            int rowsAffected = shipperRepository.DeleteShipper(shipperId);

            System.Console.WriteLine("Rows affected: {0}", rowsAffected);
        }

        private static void PrintAllShippers(IEnumerable<IShipper> shippers)
        {
            foreach (var item in shippers)
            {
                PrintShippers(item);
            }
        }

        private static void PrintShippers(IShipper shipper)
        {
            System.Console.WriteLine("ShipperId: {0} ¦ CompanyName: {1}", shipper.ShipperId, shipper.CompanyName);
        }
    }
}
