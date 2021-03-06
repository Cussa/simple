﻿using System;


namespace Simple.Data
{
    public class SimpleTransformers
    {
        public static TupleToDictionaryTransformer ToDictionary = new TupleToDictionaryTransformer();

        public static TupleToConstructorTransformer ByConstructor(Type t)
        {
            return new TupleToConstructorTransformer(t);
        }
        public static TupleToConstructorTransformer ByConstructor<T>()
        {
            return ByConstructor(typeof(T));
        }

        public static TupleToPropertiesTransformer ByProperties(Type t)
        {
            return new TupleToPropertiesTransformer(t);
        }
        public static TupleToPropertiesTransformer ByProperties<T>()
            where T : new()
        {
            return ByProperties(typeof(T));
        }

    }

}
