﻿using System.Collections.Generic;

namespace Eloqua
{
    public class GenericClient<T> where T : IRestObject, new()
    {
        public GenericClient(GenericRequest request)
        {
            _request = request;
        }
        readonly GenericRequest _request;

        public T Get(int id)
        {
            return _request.Get<T> (new T
                                          {
                                              Id = id
                                          });
        }

        public IList<T> Get(string search, int pageNumber, int pageSize)
        {
            return _request.Search<T> (new T
                                                   {
                                                       SearchTerm = search, 
                                                       PageNumber = pageNumber, 
                                                       PageSize = pageSize
                                                   });
        }

        public T Post(T restObj)
        {
            return _request.Post<T>(restObj);
        }

        public T Put(T restObj)
        {
            return _request.Put<T>(restObj);
        }

        public void Delete(int id)
        {
            _request.Delete<T> (new T
                                      {
                                          Id = id
                                      });
        }
    }
}
