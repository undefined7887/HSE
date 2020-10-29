Name:		texlive-actuarialsymbol
Version:	1.1
Release:	1
Summary:	TexLive package provides commands to compose actuarial symbols
Group:		Publishing
URL:		https://ctan.org/tex-archive/macros/latex/contrib/actuarialsymbol
License:	LPPL1.3
Source0:	http://ctan.altspu.ru/systems/texlive/tlnet/archive/actuarialsymbol.tar.xz
Source1:	http://ctan.altspu.ru/systems/texlive/tlnet/archive/actuarialsymbol.doc.tar.xz
BuildArch:	noarch
BuildRequires: texlive-tlpkg
Requires: texlive-actuarialangle
Requires(pre): texlive-tlpkg
Requires(post):texlive-kpathsea

%description
This package provides commands to compose actuarial symbols of life contingencies and financial mathematics characterized by subscripts and superscripts on both sides of a principal symbol. The package also features commands to easily and consistently position precedence numbers above or below statuses in symbols for multiple lives contracts.

Since the actuarial notation can get quite involved, the package defines a number of shortcut macros to ease entry of the most common elements.

Appendix A of the package documentation lists the commands to typeset a large selection of symbols of life contingencies.

#-----------------------------------------------------------------------
%files
%{_texmfdistdir}/tex/latex/actuarialsymbol/actuarialsymbol
%{_texmfdistdir}/tex/latex/actuarialsymbol/mosaic.jpg
%doc %{_texmfdistdir}/doc/latex/actuarialsymbol/README.md
%doc %{_texmfdistdir}/doc/latex/actuarialsymbol/actuarialsymbol.pdf

#-----------------------------------------------------------------------
%prep
%setup -c -a0 -a1

%build

%install
mkdir -p %{buildroot}%{_texmfdistdir}
cp -fpar tex doc source %{buildroot}%{_texmfdistdir}