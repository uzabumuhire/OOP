namespace DoubleDispatch
{
    using System;
    using System.Collections.Generic;

    using Ships;
    using Polymorphic = Shapes.Polymorphic;
    using Overloaded = Shapes.Overloaded;
    using PSB = Shapes.PolymorphicStaticBinding;
    using DD = Shapes.DoubleDispatch;

    class Program
    {
        static void Main(string[] args)
        {
            PrintInfo("SHIPS");
            RunShips();

            PrintInfo("SHAPES");

            PrintInfo("Polymorphism : ");
            DrawPolymorphicShapes();

            PrintInfo("Overloading :");
            DrawOverloadedShapes();

            PrintInfo("Polymorphic static binding : ");
            DrawShapesOnSurfacesUsingPolymorphicStaticBinding();

            PrintInfo("Double Dispatch : ");
            DrawShapesOnSurfacesUsingDoubleDispatch();
        }

        static void RunShips()
        {
            ImperialShip unscannedShip = new ImperialShip();
            ImperialShip enemyUnscannedShip = new ImperialShip();

            ImperialShip scannedShip = new DauntlessCruiser();
            ImperialShip enemyScannedShip = new DauntlessCruiser();

            DauntlessCruiser enemyShipInVisualRange = new DauntlessCruiser();

            // 'Dispatch' is a problem of figuring out which methods to call –
            // specifically, how many pieces of information are required in order to
            // make the call.

            // Polymorphically: there is a way we can coerce the system to invoke the
            // correct overload without any runtime checks. A polymorphic call can be
            // dispatched right to the necessary component. Which in turn can call the
            // necessary overload. This is called 'double dispatch' because:
            // 1. First you do a polymorphic call on the actual object
            // 2. Inside the polymorphic call, you call the overload. Since, inside
            //    the object, 'this' has a precise type, the right overload is triggered.
            //    The polymorphic call must be inside each distinct implementation so 
            //    'this' pointer is suitably typed.

            // Double dispatch is when methods are dispatched based on the run time (or
            // dynamic) type of two things; the object being called and its parameters.

            // Single disaptch only pays attention to the type of one thing, the object
            // that the method was called upon. For the arguments, it just uses the 
            // compile time types. 

            enemyUnscannedShip.FiredUponBy(unscannedShip);
            enemyScannedShip.FiredUponBy(unscannedShip);
            enemyShipInVisualRange.FiredUponBy(unscannedShip);
            enemyUnscannedShip.FiredUponBy(scannedShip);
            enemyScannedShip.FiredUponBy(scannedShip);
            enemyShipInVisualRange.FiredUponBy(scannedShip);
        }

        static void DrawPolymorphicShapes()
        {
            // A hierarchy of shapes are defined with each of the derived
            // types overriding a base virtual Draw() method.

            // Note that the proper Draw() method is called for each item
            // in the collection.  In most object-oriented languages, this
            // polymorphic behavior is achieved through the use of a virtual
            // table consulted at run-time to derive the proper offset
            // address for an object’s method.  This behavior is referred
            // to as “Dynamic Dispatch” or “Single Dispatch”.

            var shapes = new List<Polymorphic.Shape>
            {
                new Polymorphic.Shape(),
                new Polymorphic.Polygon(),
                new Polymorphic.Quadrilateral(),
                new Polymorphic.Rectangle()
            };

            foreach (var shape in shapes)
                shape.Draw();
        }

        static void DrawOverloadedShapes()
        {
            // Note that the parameter type determines which Draw() method is invoked.
            var shape = new Overloaded.Shape();
            shape.Draw(new Overloaded.Surface());
            shape.Draw(new Overloaded.EtchASketch());

            var s = new Overloaded.Shape();
            Overloaded.Surface surface = new Overloaded.Surface();
            Overloaded.Surface etchASktech = new Overloaded.EtchASketch();
            s.Draw(surface);

            // The issue here is that the method to call was determined statically at
            // compile time based upon the reference type, not at run-time based
            // upon the object type.
            s.Draw(etchASktech);
        }

        static void DrawShapesOnSurfacesUsingPolymorphicStaticBinding()
        {
            var shape = new PSB.Shape();
            PSB.Surface surface = new PSB.Surface();
            PSB.Surface etchASktech = new PSB.EtchASketch();

            // Polymorphic static binding is a technique where static method invocations
            // are determined at run-time through the use of polymorphism.

            // Add a new Draw(Shape shape) method to the Surface and EtchASketch types
            // which call shape.Draw() with a reference to the current object.

            // To invoke the correct Shape.Draw() method, call the desired method
            // indirectly through a Surface reference.

            //  Achieves the desired result by effectively wrapping the static-dispatched
            //  method invocation (i.e. Shape.Draw()) within a virtual-dispatch method
            //  invocation (i.e. Surface.Draw() and EtchASketch.Draw()). This causes the
            //  static Shape.Draw() method invocation to be determined by which virtual
            //  Surface.Draw() method invocation is executed.

            surface.Draw(shape);
            etchASktech.Draw(shape);
        }

        static void DrawShapesOnSurfacesUsingDoubleDispatch()
        {
            // To demonstrate Double Dispatch, the techniques from both the polymorphism
            // example and the polymorphic static binding example need to be combined.

            // A hierarchy of Surface types and a hierarchy of Shape types. Each Shape
            // type contains an overloaded virtual Draw() method which contains the logic
            // for how the shape is to be drawn on a particular surface. We use the
            // polymorphic static binding technique here to ensure the proper overload
            // is called for each surface type.

            // Virtual dispatch occurs twice for each call to one of the Surface references:
            // Once when the Surface.Draw() virtual method is called and again when either
            // calls the Shape.Draw() overloaded virtual method. Note again that while the
            // second virtual dispatch is based on the type of Shape instance, the overloaded
            // method called is still determined statically based upon the reference type.

            var shape = new DD.Shape();
            DD.Surface surface = new DD.Surface();
            DD.Surface etchASktech = new DD.EtchASketch();

            var shapes = new List<DD.Shape>
            {
                new DD.Shape(),
                new DD.Polygon(),
                new DD.Quadrilateral(),
                new DD.Rectangle()
            };

            foreach (var s in shapes)
            {
                surface.Draw(s);
                etchASktech.Draw(s);
            }
        }

        static void PrintInfo(string info)
        {
            Console.WriteLine($"\n{info}\n");
        }
    }
}
