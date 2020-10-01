using System;
using System.Collections.Generic;
using System.Linq;

namespace VicMoneyTracker
{
    /// <summary>
    /// Data model that tracks Victorian money: pounds, crowns, shillings, pence, farthings.
    /// Amounts can be converted between these types. All amounts must either be positive
    /// numbers, or zero.
    /// </summary>
    class Money
    {

        // Instance variable for each type of money. Initially all have no amount (i.e. 0).
        // Setters validate the amounts, and throw an exception if invalid (i.e. negative).

        private int _pounds = 0;
        /// <summary>
        /// Number of pounds
        /// </summary>
        public int pounds
        {
            get => _pounds;
            set => _pounds = ValidatedAmount(value);
        }

        private int _crowns = 0;
        /// <summary>
        /// Number of crowns
        /// </summary>
        public int crowns
        {
            get => _crowns;
            set => _crowns = ValidatedAmount(value);
        }

        private int _shillings = 0;
        /// <summary>
        /// Number of shillings
        /// </summary>
        public int shillings
        {
            get => _shillings;
            set => _shillings = ValidatedAmount(value);
        }

        private int _pence = 0;
        /// <summary>
        /// Number of pence
        /// </summary>
        public int pence
        {
            get => _pence;
            set => _pence = ValidatedAmount(value);
        }

        private int _farthings = 0;
        /// <summary>
        /// Number of farthings
        /// </summary>
        public int farthings
        {
            get => _farthings;
            set => _farthings = ValidatedAmount(value);
        }

        // Conversion factors
        private static readonly int crownsPerPound = 4;
        private static readonly int shillingsPerCrown = 5;
        private static readonly int pencePerShilling = 12;
        private static readonly int farthingsPerPenny = 4;

        // Booleans properties for whether conversions can occur
        public bool canConvertPoundsToCrowns => pounds > 0;
        public bool canConvertCrownsToShillings => crowns > 0;
        public bool canConvertShillingsToPence => shillings > 0;
        public bool canConvertPenceToFarthings => pence > 0;
        public bool canConvertFarthingsToPence => farthings >= farthingsPerPenny;
        public bool canConvertPenceToShillings => pence >= pencePerShilling;
        public bool canConvertShillingsToCrowns => shillings >= shillingsPerCrown;
        public bool canConvertCrownsToPounds => crowns >= crownsPerPound;

        // The labels for money types depend on the amount
        public string poundsLabel => pounds == 1 ? "pound" : "pounds";
        public string crownsLabel => crowns == 1 ? "crown" : "crowns";
        public string shillingsLabel => shillings == 1 ? "shilling" : "shillings";
        public string penceLabel => pence == 1 ? "penny" : "pence";
        public string farthingsLabel => farthings == 1 ? "farthing" : "farthings";

        /// <summary>
        /// Validates values when setting money amounts. Throws an exception if the value is negative,
        /// others returns the value passed in.
        /// </summary>
        /// <param name="amount">Amount to be validates</param>
        /// <returns>Amount passed in</returns>
        /// <exception cref="Exception"></exception>
        private static int ValidatedAmount(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Money amounts must be postive");
            }
            return amount;
        }

        /// <summary>
        /// Returns a human-readable string of the total amount. Omits a money type if its amount is zero.
        /// If there is no money of any type, returns "Nil".
        /// </summary>
        /// <returns>Total amount of money</returns>
        public override string ToString()
        {
            // When there is no money, just return "Nil"
            if (pounds == 0 && crowns == 0 && shillings == 0 && pence == 0 && farthings == 0)
            {
                return "Nil";
            }
            // Get the formatted version of each money amount, and then remove any which are empty
            IEnumerable<string> formattedValues = new string[] {
                FormattedPounds(),
                FormattedCrowns(),
                FormattedShillings(),
                FormattedPence(),
                FormattedFarthings()
            }.Where(val => val != "");
            // The remaining formatted versions can now be joined into a single string
            return string.Join(" ", formattedValues);


            // Strings for each momey type, or empty string if the value is 0

            // Join all strings together, trim to get rid of any trailing spaces
            //return (poundsTotal + crownsTotal + shillingsTotal + penceTotal + farthingsTotal).Trim();
        }

        /// <summary>
        /// Formats the pounds value with its symbol, if there are any pounds
        /// </summary>
        /// <returns>Formatted pounds value, or empty string</returns>
        public string FormattedPounds() => pounds > 0 ? "£" + pounds : "";

        /// <summary>
        /// Formats the crowns value with its symbol, if there are any crowns
        /// </summary>
        /// <returns>Formatted crowns value, or empty string</returns>
        public string FormattedCrowns() => crowns > 0 ? crowns + "c" : "";

        /// <summary>
        /// Formats the shillings value with its symbol, if there are any shillings
        /// </summary>
        /// <returns>Formatted shillings value, or empty string</returns>
        public string FormattedShillings() => shillings > 0 ? shillings + "s" : "";

        /// <summary>
        /// Formats the pence value with its symbol, if there are any
        /// </summary>
        /// <returns>Formatted pence value, or empty string</returns>
        public string FormattedPence() => pence > 0 ? pence + "d" : "";

        /// <summary>
        /// Formats the farthings value with its symbol, if there are any
        /// </summary>
        /// <returns>Formatted farthing value, or empty string</returns>
        public string FormattedFarthings() => farthings > 0 ? farthings + "f" : "";

        // Methods to convert down between types:

        /// <summary>
        /// Converts 1 pound into crowns, if possible
        /// </summary>
        public void ConvertPoundToCrowns()
        {
            if (canConvertPoundsToCrowns)
            {
                crowns += crownsPerPound;
                pounds--;
            }
        }

        /// <summary>
        /// Converts 1 crown into shillings, if possible
        /// </summary>
        public void ConvertCrownToShillings()
        {
            if (canConvertCrownsToShillings)
            {
                shillings += shillingsPerCrown;
                crowns--;
            }
        }

        /// <summary>
        /// Converts 1 shilling into pence, if possible
        /// </summary>
        public void ConvertShillingToPence()
        {
            if (canConvertShillingsToPence)
            {
                pence += pencePerShilling;
                shillings--;
            }
        }

        /// <summary>
        /// Converts 1 penny into farthings, if possible
        /// </summary>
        public void ConvertPennyToFarthings()
        {
            if (canConvertPenceToFarthings)
            {
                farthings += farthingsPerPenny;
                pence--;
            }
        }


        // Methods to convert up between types:

        /// <summary>
        /// Converts farthings into 1 penny, if possible
        /// </summary>
        public void ConvertFarthingsToPenny()
        {
            if (canConvertFarthingsToPence)
            {
                pence++;
                farthings -= farthingsPerPenny;
            }
        }

        /// <summary>
        /// Converts pence into 1 shilling, if possible
        /// </summary>
        public void ConvertPenceToShilling()
        {
            if (canConvertPenceToShillings)
            {
                shillings++;
                pence -= pencePerShilling;
            }
        }

        /// <summary>
        /// Converts shillings into 1 crown, if possible
        /// </summary>
        public void ConvertShillingsToCrown()
        {
            if (canConvertShillingsToCrowns)
            {
                crowns++;
                shillings -= shillingsPerCrown;
            }
        }

        /// <summary>
        /// Converts crowns into 1 pound, if possible
        /// </summary>
        public void ConvertCrownsToPound()
        {
            if (canConvertCrownsToPounds)
            {
                pounds++;
                crowns -= crownsPerPound;
            }
        }

    }
}
