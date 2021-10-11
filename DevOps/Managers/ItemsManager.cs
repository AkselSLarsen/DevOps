using DevOps.Model;
using System.Collections.Generic;

namespace DevOps.Managers {
    public class SandwichManager {
        private static int _nextNr = 1;
        private static readonly List<Sandwich> Data = new List<Sandwich>
        {
           new Sandwich(_nextNr++, "Skinke", 25, 200, "Lyst Brød, skinke og ost."),
           new Sandwich(_nextNr++, "En anden sandwich", 30, 250, "Det ved jeg sku ikke lige...")
        };

        public List<Sandwich> GetAll(string substring) {
            if(string.IsNullOrWhiteSpace(substring)) {
                return new List<Sandwich>(Data);
            }

            List<Sandwich> re = new List<Sandwich>();

            foreach (Sandwich sandwich in Data) {
                if(sandwich.Name.ToLower().Contains(substring.ToLower())) {
                    re.Add(sandwich);
                }
            }
            return re;
        }

        public Sandwich GetByNr(int nr) {
            return Data.Find(sandwich => sandwich.Nr == nr);
        }

        public Sandwich Add(Sandwich newSandwich) {
            newSandwich.Nr = _nextNr++;
            
            Data.Add(newSandwich);
            return newSandwich;
        }

        public Sandwich Add(Sandwich newSandwich, int nr) {
            newSandwich.Nr = nr;

            Data.Add(newSandwich);
            return newSandwich;
        }

        public Sandwich Delete(int nr) {
            Sandwich sandwich = Data.Find(sandwich1 => sandwich1.Nr == nr);
            if (sandwich == null) return null;
            Data.Remove(sandwich);
            return sandwich;
        }

        public Sandwich Update(int nr, Sandwich updatedSandwich) {
            Sandwich sandwich = Delete(nr);
            Add(updatedSandwich, nr);

            return sandwich;
        }
    }
}