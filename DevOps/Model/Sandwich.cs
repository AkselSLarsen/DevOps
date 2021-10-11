using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps.Model {
    public class Sandwich {
        private int _nr;
        private string _name;
        private float _price;
        private float _weightInGrams;
        private string _ingredients;

        public int Nr {
            get {
                return _nr;
            }
            set {
                _nr = value;
            }
        }

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }

        public float Price {
            get {
                return _price;
            }
            set {
                _price = value;
            }
        }

        public float WeightInGrams {
            get {
                return _weightInGrams;
            }
            set {
                _weightInGrams = value;
            }
        }

        public float WeightInKiloes {
            get {
                return _weightInGrams / 1000;
            }
            set {
                _weightInGrams = value * 1000;
            }
        }

        public string Ingredients {
            get {
                return _ingredients;
            }
            set {
                _ingredients = value;
            }
        }

        public Sandwich(int nr, string name, float price, float weightInGrams, string ingredients) {
            Nr = nr;
            Name = name;
            Price = price;
            WeightInGrams = weightInGrams;
            Ingredients = ingredients;
        }

    }
}
