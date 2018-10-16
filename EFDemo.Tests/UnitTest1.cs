using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFDemo.Tests
{
    [TestClass]
    public class EFDemoTests
    {
        [TestMethod]
        public void Can_Create_EFContext()
        {
            EFContext ctx = new EFContext();
        }

        [TestMethod]
        public void Can_Create_DB()
        {
            using (EFContext ctx = new EFContext())
            {
                if (ctx.Database.Exists())
                    ctx.Database.Delete();

                Assert.IsFalse(ctx.Database.Exists());

                ctx.Database.Create();

                Assert.IsTrue(ctx.Database.Exists());
            }
        }


        [TestMethod]
        public void Can_Insert_multiple_Persons()
        {
            using (EFContext ctx = new EFContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    Person p = new Person
                    {
                        Vorname = $"Tom{i}",
                        Nachname = $"Ate{i}",
                        Alter = Convert.ToByte(i),
                        Kontostand = i * 50,
                    };
                    ctx.Person.Add(p);
                }

                ctx.SaveChanges();
            }
        }

        [TestMethod]
        public void Can_Get_Personen_With_Kontostand_Higher_Than_200()
        {
            using (EFContext ctx = new EFContext())
            {
                var query = ctx.Person.Where(x => x.Kontostand >= 200);
                // Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
                // Trace.WriteLine(query.ToString());
                var sqlQuery = query.ToString();
                var result = query.ToList();
                Assert.IsNotNull(result);
            }
        }
    }
}
