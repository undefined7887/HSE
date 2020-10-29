Name:		translator
Version:	1.12c
Release:	1
Summary:	TexLive package to translate individual words
Group:		Publishing
URL:		https://ctan.org/tex-archive/macros/latex/contrib/translator
License:	LPPL1.3
Source0:	http://ctan.altspu.ru/systems/texlive/tlnet/archive/translator.tar.xz
Source1:	http://ctan.altspu.ru/systems/texlive/tlnet/archive/translator.doc.tar.xz
BuildArch:	noarch
BuildRequires: texlive-tlpkg
Requires(pre): texlive-tlpkg
Requires(post):texlive-kpathsea

%description
The translator package is a LATEX package that provides a flexible mechanism for translating individual words into different languages. For example, it can be used to translate a word like figure into, say, the German word Abbildung. Such a translation mechanism is useful when the author of some package would like to localize the package such that texts are correctly translated into the language preferred by the user. The translator package is not intended to be used to automatically translate more than a few words.

#-----------------------------------------------------------------------
%files
%{_texmfdistdir}/tex/latex/translator/translator
%doc %{_texmfdistdir}/doc/latex/translator/README.md
%doc %{_texmfdistdir}/doc/latex/translator/translator.tex
%doc %{_texmfdistdir}/doc/latex/translator/translator.pdf

#-----------------------------------------------------------------------
%prep
%setup -c -a0 -a1

%build

%install
mkdir -p %{buildroot}%{_texmfdistdir}
cp -fpar tex doc source %{buildroot}%{_texmfdistdir}