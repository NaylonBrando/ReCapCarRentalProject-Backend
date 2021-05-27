using Business.Abstract;
using Business.Constants;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color T)
        {
            _colorDal.Add(T);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Color T)
        {
            _colorDal.Delete(T);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == id));
        }

        public IResult Update(Color T)
        {
            _colorDal.Update(T);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
