using System.Collections;
using System.Collections.Generic;
using System.Linq.Dynamic.Tests.Helpers;

namespace System.Linq.Dynamic.x.ConsoleTestApp.net40
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--start");

            Where();
            ExpressionTests_Sum();
            Select();

            Console.WriteLine("--end");
        }

        public static void Where()
        {
            //Arrange
            var testList = User.GenerateSampleModels(100, allowNullableProfiles: true);
            var qry = testList.AsQueryable();


            //Act
            var userById = qry.Where("Id=@0", testList[10].Id);
            var userByUserName = qry.Where("UserName=\"User5\"");
            var nullProfileCount = qry.Where("Profile=null");
            var userByFirstName = qry.Where("Profile!=null && Profile.FirstName=@0", testList[1].Profile.FirstName);


            //Assert
            Write(testList[10], userById.Single());
            Write(testList[5], userByUserName.Single());
            Write(testList.Count(x => x.Profile == null), nullProfileCount.Count());
            Write(testList[1], userByFirstName.Single());
        }

        public static void ExpressionTests_Sum()
        {
            //Arrange
            int[] initValues = new int[] { 1, 2, 3, 4, 5 };
            var qry = initValues.AsQueryable().Select(x => new { strValue = "str", intValue = x }).GroupBy(x => x.strValue);

            //Act
            var result = qry.Select("Sum(intValue)").AsEnumerable().ToArray()[0];

            //Assert
            Write(15, result);
        }

        public static void Select()
        {
            //Arrange
            List<int> range = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var testList = User.GenerateSampleModels(100);
            var qry = testList.AsQueryable();

            //Act
            IEnumerable rangeResult = range.AsQueryable().Select("it * it");
            var userNames = qry.Select("UserName");
            var userFirstName = qry.Select("new (UserName, Profile.FirstName as MyFirstName)");
            var userRoles = qry.Select("new (UserName, Roles.Select(Id) AS RoleIds)");


            //Assert
            WriteArray(range.Select(x => x * x).ToArray(), rangeResult.Cast<int>().ToArray());
            WriteArray(testList.Select(x => x.UserName).ToArray(), userNames.ToDynamicArray());
            WriteArray(testList.Select(x => "{UserName=" + x.UserName + ", MyFirstName=" + x.Profile.FirstName + "}").ToArray(), userFirstName.AsEnumerable().Select(x => x.ToString()).ToArray());

            Guid[] check = testList[0].Roles.Select(x => x.Id).ToArray();
            //dynamic f = userRoles.First();
            //Guid[] ids = f.RoleIds.ToArray();
            Guid[] result = Enumerable.ToArray(userRoles.First().RoleIds);

            WriteArray(check, result);
        }

        private static void Write<T>(T check, T result) where T : class
        {
            Console.WriteLine("> '{0}'", check == result);
        }

        private static void Write(int check, int result)
        {
            Console.WriteLine("> '{0}'", check == result);
        }

        private static void WriteArray<T>(T[] check, T[] result) where T : class
        {
            for (int i = 0; i < check.Length; i++)
            {
                Console.WriteLine("> {0} : c={1}, r={2}  '{3}'", i, check[i], result[i], check[i] == result[i]);
            }
        }

        private static void WriteArray(Guid[] check, Guid[] result)
        {
            for (int i = 0; i < check.Length; i++)
            {
                Console.WriteLine("> {0} : c={1}, r={2}  '{3}'", i, check[i], result[i], check[i] == result[i]);
            }
        }

        private static void WriteArray(int[] check, int[] result)
        {
            for (int i = 0; i < check.Length; i++)
            {
                Console.WriteLine("> {0} : c={1}, r={2}  '{3}'", i, check[i], result[i], check[i] == result[i]);
            }
        }
    }
}
