using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorSample
{
    /*Attaches additional responsibility to an object dynamically.
     * */
    class DecoratorPtrn
    {
        static void Main(string[] args)
        {
            Component compA = new ConcreteComponentA();
            Component compB = new ConcreteComponentB();

            compA.Display();

            Decorator deco = new ConcreteDecorator();
            deco.SetComponent(compA);

            deco.Display();

            Console.ReadLine();
        }
    }

    public abstract class Component
    {
        public abstract void Display();
    }

    public class ConcreteComponentA : Component
    {
        public override void Display()
        {
            Console.WriteLine("ConcreateComponentA");
        }

    }

    public class ConcreteComponentB : Component
    {
        public override void Display()
        {
            Console.WriteLine("ConcreateComponentB");
        }

    }

    public abstract class Decorator : Component
    {
        protected Component _component;
        public void SetComponent(Component component)
        {
            _component = component;
        }

        public override void Display()
        {
            _component.Display();
        }
    }

    public class ConcreteDecorator : Decorator
    {
        public override void Display()
        {
            Console.WriteLine("Borrowing display of concretecomponentA");
            base.Display();
            Console.WriteLine("Decorating same with ConcreteDecorator");
        }
    }
}
