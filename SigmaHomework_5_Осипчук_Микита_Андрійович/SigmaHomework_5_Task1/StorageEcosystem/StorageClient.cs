using SigmaHomework_5_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_5_Task1.Enums;
using SigmaHomework_5_Task1.ProductFactories;

namespace SigmaHomework_5_Task1.StorageEcosystem
{
    public class StorageClient
    {
        private readonly Storage _storage;

        public StorageClient(Storage storage)
        {
            _storage = storage;
        }



        public void Print()
        {
            StringBuilder stringBuilder = new StringBuilder();

            _storage.Products.ForEach(product => stringBuilder.AppendLine(product.ToString()));

            Console.WriteLine("STORAGE: \n" + stringBuilder);
        }

        public void AddProductsToStorageWithConsole()
        {
            string? assemblyName = Assembly.GetAssembly(GetType())?.GetName().Name;
            if (assemblyName == null)
                throw new NullReferenceException($"Assembly was not found");

            string typePath = $"{assemblyName}.ProductsModels.ProductModel";

            Console.WriteLine("Сhoose Class type:");
            Type? productType = Type.GetType(typePath);
            if (productType == null)
                throw new NullReferenceException($"Product type was not found in '{assemblyName}.ProductsModels' directory");

            List<Type>? listOfProductSubclassesTypes = Assembly
                .GetAssembly(productType)?
                .GetTypes()
                .Where(type => type.IsSubclassOf(productType))
                .ToList();
            if (listOfProductSubclassesTypes == null)
                throw new NullReferenceException($"Assembly was not using '{assemblyName}.ProductsModels.ProductModel' directory");

            listOfProductSubclassesTypes.Add(productType);

            int answer = ConsoleAnswers.GetIndexAnswerByArray(
                new List<string>(listOfProductSubclassesTypes.Select(type => type.Name[..^5])),
                "Enter number of product type: ");

            string typeAnswer = listOfProductSubclassesTypes[answer].Name;
            Type? factoryType = Type.GetType($"{assemblyName}.ProductFactories.{typeAnswer[..^5]}Factory");
            if (factoryType == null)
                throw new NullReferenceException("No factory for this type of Product");

            var factory = Activator.CreateInstance(factoryType) as IProductFactory;
            if (factory == null)
                throw new NullReferenceException("No factory for this type of Product");

            _storage.Products.Add(factory.Create());
        }
    }
}
