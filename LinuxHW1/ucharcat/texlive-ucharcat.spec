Name:		ucharcat
Version:	0.03
Release:	1
Summary:	TexLive package implements \Ucharcat command
Group:		Publishing
URL:		https://ctan.org/tex-archive/macros/latex/contrib/ucharcat
License:	LPPL1.3
Source0:	http://ctan.altspu.ru/systems/texlive/tlnet/archive/ucharcat.tar.xz
Source1:	http://ctan.altspu.ru/systems/texlive/tlnet/archive/ucharcat.doc.tar.xz
BuildArch:	noarch
BuildRequires: texlive-tlpkg
Requires(pre): texlive-tlpkg
Requires(post):texlive-kpathsea

%description
The package implements the \Ucharcat command for LuaLATEX. \Ucharcat is a new primitive in XETEX, an extension of the existing \Uchar command, that allows the specification of the catcode as well as character code of the character token being constructed.

#-----------------------------------------------------------------------
%files
%{_texmfdistdir}/tex/latex/ucharcat/ucharcat
%doc %{_texmfdistdir}/doc/latex/ucharcat/README.md
%doc %{_texmfdistdir}/doc/latex/ucharcat/ucharcat.pdf

#-----------------------------------------------------------------------
%prep
%setup -c -a0 -a1

%build

%install
mkdir -p %{buildroot}%{_texmfdistdir}
cp -fpar tex doc source %{buildroot}%{_texmfdistdir}