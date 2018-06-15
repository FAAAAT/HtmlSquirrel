using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using NSoup;
using NSoup.Nodes;

namespace HtmlSquirrel
{
    public class HtmlParser
    {
        private string url;

        private IRequester requester;

        public Document HtmlDocument { get; private set; }



        public HtmlParser(string url, IRequester requester)
        {
            this.url = url;

            HtmlDocument = NSoupClient.Parse(requester.GetContent(url));
        }





    }

    public class DocumentDataConverter : IDataConverter<Document, CHHSellArticalDataModel>
    {
        public IEnumerable<Action<Document, CHHSellArticalDataModel>> acts;

        public CHHSellArticalDataModel RunConverter(Document source)
        {
            foreach (Action<Document, CHHSellArticalDataModel> action in acts)
            {

            }
        }
    }

    public interface IDataConverter<TSource, TResult>
    {
        TResult RunConverter(TSource source);

    }

    public class EnumerableCallSite<TSource, TArgument, TResult> : CallSite<TSource, TArgument, TResult>
    {
        public IEnumerable<ICallSite<TSource, TArgument, TResult>> ChildCallSites;

        public EnumerableCallSite()
        {
            Kind = SiteKind.Enumerble;
        }

        public override TResult VisitEnumerableCallSite(TSource source, TArgument arg)
        {
            return default(TResult);
        }

    }

    public class CHHArticleEnumerbleCallSite : EnumerableCallSite<Document, CHHSellArticalDataModel, int>
    {

        public override int VisitEnumerableCallSite(Document source, CHHSellArticalDataModel arg)
        {
            
        }
    }

    public class ObjectCallSite<TSource, TArgument, TResult> : CallSite<TSource, TArgument, TResult>
    {
        public IEnumerable<ICallSite<TSource, TArgument, TResult>> ChildCallSites;

        public ObjectCallSite()
        {
            Kind = SiteKind.Object;
        }

        public override TResult VisitObjectCallSite(TSource source, TArgument arg)
        {
            return default(TResult);
        }
    }
    
    public class PropertyCallSite<TSource, TArgument, TResult> : CallSite<TSource, TArgument, TResult>
    {
        public PropertyCallSite()
        {
            Kind = SiteKind.Property;
        }

        public override TResult VisitPropertyCallSite(TSource source, TArgument arg)
        {
            return default(TResult);
        }
    }


    public abstract class CallSite<TSource, TArgument, TResult> : ICallSite<TSource, TArgument, TResult>
    {
        public SiteKind Kind { get; set; }
        public virtual TResult VisitCallSite(TSource source, TArgument arg)
        {
            if (Kind == SiteKind.Enumerble)
            {
                return VisitEnumerableCallSite(source, arg);
            }
            else if (Kind == SiteKind.Object)
            {
                return VisitObjectCallSite(source, arg);
            }
            else if (Kind == SiteKind.Property)
            {
                return VisitPropertyCallSite(source, arg);
            }
            else
            {
                throw new Exception("Unknown Kind");
            }
        }

        public virtual TResult VisitEnumerableCallSite(TSource source, TArgument arg)
        {
            throw new NotImplementedException();
        }

        public virtual TResult VisitObjectCallSite(TSource source, TArgument arg)
        {
            throw new NotImplementedException();

        }

        public virtual TResult VisitPropertyCallSite(TSource source, TArgument arg)
        {
            throw new NotImplementedException();

        }

    }




    public interface ICallSite<TSource,TArgument,TResult>
    {
        SiteKind Kind { get; set; }
        TResult VisitCallSite(TSource source, TArgument arg);

    }

    public enum SiteKind
    {
        Enumerble,Object,Property
    }
}
