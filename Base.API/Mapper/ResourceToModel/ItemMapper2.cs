﻿using AutoMapper;
using Base.Core.Entity;
using Base.Core.Enum;
using Base.Core.Identity;
using Base.Core.ViewModel;

namespace Base.API.Mapper.ResourceToModel;

public class ItemMapper2 : Profile
{
    public ItemMapper2()
    {
        CreateMap<Service, ResponseServiceVM>()
            .ForMember(dest => dest.ServicePackages, opt => opt.MapFrom(src => src.ServicePackages));

        CreateMap<ServicePackage, ResponseServicePackageVM>()
            .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services))
            .ForMember(dest => dest.ValuableVoucherTypes, opt => opt.MapFrom(src => src.ValuableVoucherTypes));

        CreateMap<Booking, ResponseBookingVM>()
            .ForMember(dest => dest.Vouchers, opt => opt.MapFrom(src => src.Vouchers))
            .ForMember(dest => dest.BookingStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(BookingStatus), src.BookingStatus)));

        CreateMap<VoucherType, ResponseVoucherTypeVM>()
            .ForMember(dest => dest.Vouchers, opt => opt.MapFrom(src => src.Vouchers))
            .ForMember(dest => dest.UsableServicePackages, opt => opt.MapFrom(src => src.UsableServicePackages));

        CreateMap<Voucher, ResponseVoucherVM>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings))
            .ForMember(dest => dest.VoucherExtensions, opt => opt.MapFrom(src => src.VoucherExtensions))
            .ForMember(dest => dest.VoucherStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(VoucherStatus), src.VoucherStatus)));

        CreateMap<Customer, ResponseCustomerVM>();

        CreateMap<Customer, ResponseCustomerInformationVM>()
            .ForMember(dest => dest.Vouchers, opt => opt.MapFrom(src => src.Vouchers))
            .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings));

        CreateMap<User, ResponseUserVM>();

        CreateMap<User, ResponseUserInformationVM>()
            .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers))
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles));

        CreateMap<ExpiredDateExtension, ResponseExpiredDateExtensionVM>();

        CreateMap<Role, ResponseRoleVM>();

        //This mapping is used for Booking entity only
        CreateMap<Voucher, ResponseVoucherForBookingVM>()
            .ForMember(dest => dest.VoucherStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(VoucherStatus), src.VoucherStatus)));
        CreateMap<VoucherType, ResponseVoucherTypeForBookingVM>();
        //=================================


        //This mapping is used for Expired Date Extension entity only
        CreateMap<Voucher, ResponseVoucherForExtensionVM>()
            .ForMember(dest => dest.VoucherStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(VoucherStatus), src.VoucherStatus)));
        CreateMap<VoucherType, ResponseVoucherTypeForExtensionVM>();
        //==================================
    }
}