using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppEF_MVVM_promUa.Models;

namespace WpfAppEF_MVVM_promUa.DbLayer
{
    public class PromuaInitializer : 
        //SqliteDropCreateDatabaseAlways<PromuaDb>
        SqliteCreateDatabaseIfNotExists<PromuaDb>
        
    {
        public PromuaInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        { }

        protected override void Seed(PromuaDb db)
        {
            //base.Seed(db);    
            Phone phone1Company1 = db.Phones.Add(new Phone { Number = "+380(67) 434-65-70" });
            Phone phone1Company2 = db.Phones.Add(new Phone { Number = "+380(99) 775-29-77" });
            Phone phone2Company2 = db.Phones.Add(new Phone { Number = "+380(68) 986-74-76" });
            db.SaveChanges();

            Company company1 = db.Companies.Add(new Company { Name = "TORGPARK", City = "г. Киев", Phones = new List<Phone> { phone1Company1 } });
            Company company2 = db.Companies.Add(new Company { Name = "ФОП Стриженов", City = "г. Киев", Phones = new List<Phone> { phone1Company2, phone2Company2 } });
            db.SaveChanges();

            Product product1 = db.Products.Add(new Product
            {
                Name = "Холодильник DIGITAL DRF-T2114W",
                Company = company1,
                Price = 5400,
                Quantity = 10,
                Image = File.ReadAllBytes(@"..\..\Images\1352941363_w200_h200_cid2760866_pid789619697-384be988.jpg")
            });
            Product product2 = db.Products.Add(new Product
            {
                Name = "Холодильник DIGITAL DRF-S5218G",
                Company = company2,
                Price = 17200,
                Quantity = 5,
                Image = File.ReadAllBytes(@"..\..\Images\1408309505_w200_h200_cid2760866_pid813727045-2f1b3b22.jpg")
            });
            db.SaveChanges();
        }
    }
}
