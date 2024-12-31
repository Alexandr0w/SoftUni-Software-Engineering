using System.Text;
using Template.Interfaces;

namespace Template
{
    public abstract class Bread : IFood
    {
        public string PrepareRecipe()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.MixIngredients());
            sb.AppendLine(this.Bake());
            sb.Append(this.Slice());

            return sb.ToString();
        }

        protected abstract string MixIngredients();
        protected abstract string Bake();

        protected virtual string Slice() => $"Slicing the {this.GetType().Name} bread!";
    }
}
