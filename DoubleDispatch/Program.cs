namespace DoubleDispatch
{
    using System;
    using System.Collections.Generic;

    using Ships;
    using Polymorphic = Shapes.Polymorphic;
    using Overloaded = Shapes.Overloaded;
    using PSB = Shapes.PolymorphicStaticBinding;
    using DD = Shapes.DoubleDispatch;
    using LC = Shapes.LowCoupling;
    using SemiOOP = MathExpressions.SemiOOP;
    using PureOOP = MathExpressions.PureOOP;

    class Program
    {
        
        static void Main(string[] args)
        {
            PrintInfo("SHIPS");

            // See Phil L. artile on Naimuri.com :
            // https://www.naimuri.com/what-even-is-double-dispatch/

            RunShips();

            PrintInfo("SHAPES");

            // See Derek Greer article on LosTechies.com :
            // https://lostechies.com/derekgreer/2010/04/19/double-dispatch-is-a-code-smell/

            // Since Double Dispatch is a technique for calling virtual overloaded
            // methods based upon parameter types which exist within an inheritance
            // hierarchy, its use may be a symptom that the Open/Closed and/or Single
            // Responsibility principles are being violated, or that responsibilities
            // may otherwise be misaligned.  This is not to say that every case of
            // Double Dispatch means something is amiss, but only that its use should
            // be a flag to reconsider your design in light of future maintenance needs.

            PrintInfo("Polymorphism : ");
            DrawPolymorphicShapes();

            PrintInfo("Overloading :");
            DrawOverloadedShapes();

            PrintInfo("Polymorphic static binding : ");
            DrawShapesOnSurfacesUsingPolymorphicStaticBinding();

            PrintInfo("Double Dispatch : ");
            DrawShapesOnSurfacesUsingDoubleDispatch();

            PrintInfo("Low Coupling : ");
            DrawShapesDecoupledFromSurfaces();


            PrintInfo("MATHEMATICAL EXPRESSIONS");

            // See Vasil Kosturski article on his blog (vkontech.com) :
            // https://vkontech.com/clash-of-styles-part-5-double-dispatch-or-when-to-abandon-oop/
            // https://vkontech.com/polymorphism-on-steroids-dive-into-multiple-dispatch-multimethods/

            PrintInfo("Semi OOP (Pattern Matching) : ");
            CalculateMathExpressionsUsingSemiOOP();

            PrintInfo("Pure OOP (Double Dispatch) : ");
            CalculateMathExpressionUsingPureOOP();
        }

        #region ShipsExample
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
        #endregion

        #region ShapesExample
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

        static void DrawShapesDecoupledFromSurfaces()
        {
            // The problem isn’t so much with Double Dispatch, but what design
            // choices might be leading to reliance upon the technique. Consider
            // for instance the hierarchy of shape types in our Double Dispatch
            // example.  What happens if we want to add a new surface?  In this
            // case, each of the shape types will need to be modified to add
            // knowledge of the new Surface type.  This violates OCP (Open/Closed
            // Principle), and in this case in a particularly egregious way (i.e.
            // Its violation is multiplied by the number of shape types we have).
            // Additionally, it violates SRP (Single Responsibility Principle).
            // Changes to how shapes are drawn on a particular surface are likely
            // to differ from surface to surface, thereby leading our shape objects
            // to change for different reasons.

            // The presence of Double Dispatch generally means that each type in a
            // hierarchy has special handling code within another hierarchy of types.
            // This approach to representing variant behavior leads to code that is
            // less resilient to future changes as well as being more difficult to
            // extend.

            // Several new concepts have been introduced to facilitate decoupling:
            // line segments, points, and brushes.

            // By changing the Shape objects to be defined in terms of line segments,
            // knowledge is removed from the shape concerning how to draw itself on
            // any particular surface.  Additionally, the Surface type now encapsulates
            // a collection of line segments to simulate the lines being drawn onto
            // the surface.  To handle drawing the line segments onto the surfaces,
            // we’ve introduced a Brush type which “draws” the line segments onto
            // a surface in its own peculiar way.  To configure which brushes are to be
            // used with which surface, we define a dictionary matching surfaces to
            // brushes.

            // In contrast to the Double Dispatch example, none of the existing types
            // need to be modified to add new surfaces, shapes, or brushes.

            var brushDictionary = new Dictionary<Type, LC.IBrush>();

            brushDictionary.Add(typeof(LC.Paper), new LC.Pencil());
            brushDictionary.Add(typeof(LC.EtchASketch), new LC.EtchASketchKnobs());

            var surfaces = new List<LC.ISurface>
            {
                new LC.Paper(),
                new LC.EtchASketch()
            };

            var shapes = new List<LC.IShape>
            {
                new LC.Polygon(),
                new LC.Quadrilateral(),
                new LC.Parallelogram(),
                new LC.Rectangle()
            };

            foreach (var surface in surfaces)
                foreach (var shape in shapes)
                {
                    Console.WriteLine(
                        string.Format("Drawing a {0} on the {1} ...", 
                            shape.GetType().Name,
                            surface.GetType().Name));

                    brushDictionary[surface.GetType()].Draw(surface, shape.GetLineSegments());

                    Console.WriteLine(Environment.NewLine);
                }
        }
        #endregion

        #region MathExpressionsExample
        static void CalculateMathExpressionsUsingSemiOOP()
        {
            var intValue = new SemiOOP.IntValue(3);
            var rationalValue = new SemiOOP.RationalValue(1, 3);

            var addition = new SemiOOP.Addition(intValue, rationalValue);
            Console.WriteLine($"{addition.Stringify()} = {addition.Eval().Stringify()}");

            var anotherAddition = new SemiOOP.Addition(rationalValue, intValue);
            Console.WriteLine($"{anotherAddition.Stringify()} = {anotherAddition.Eval().Stringify()}");

        }

        static void CalculateMathExpressionUsingPureOOP()
        {
            var intValue = new PureOOP.IntValue(3);
            var rationaValue = new PureOOP.RationalValue(1, 3);

            var addition = new PureOOP.Addition(intValue, rationaValue);
            Console.WriteLine($"{addition.Stringify()} = {addition.Eval().Stringify()}");

            var anotherAddition = new PureOOP.Addition(rationaValue, intValue);
            Console.WriteLine($"{anotherAddition.Stringify()} = {anotherAddition.Eval().Stringify()}");
        }
        #endregion

        #region Utilities
        static void PrintInfo(string info)
        {
            Console.WriteLine($"{Environment.NewLine}{info}{Environment.NewLine}");
        }
        #endregion
    }
}
