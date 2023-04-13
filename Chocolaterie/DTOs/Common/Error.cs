using Chocolaterie.Entities;

namespace Chocolaterie.DTOs.Common
{
    public static class Error
    {
        public static string FactoryNotFount = "Factory not found!";
        public static string ChocolateBarNotFount = "Chocolate Bar not found!";
        public static string WholeSalerNotFount = "WholeSaler not found!";
        public static string StockNotFount = "Stock not found!";
        public static string FactoryHasNoRightAccessNotOwnedChocolateBar = "Factory has no right access to chocolate bar not its owner!";
        public static string WholeSalerHasNoRightAccessNotOwnedChocolateBar = "WholeSaler has no right access to chocolate bar not its owner!";

        public static string OrderCannotBeEmpty = "The order cannot be empty!";
        public static string WholesalerMustExist = "The wholesaler must exist!";
        public static string CantBeDuplicatesInOrder = "There can't be any duplicates in the order!";
        public static string ChocolateBarNumberCannotBeGreaterThanStock = "The number of chocolate bars ordered cannot be greater than the wholesaler's stock!";
        public static string ChocolateBarMustBeSoldByWholeSaler = "The chocolate bar must be sold by the wholesaler!";

        public static string ClientMustExist = "The client must exist!";
        public static string LineQuantityCannotBeTessThen1 = "An order line quantity cannot be less then 1";
    }
}
