/**
 * Creating a sidebar enables you to:
 - create an ordered group of docs
 - render a sidebar for each doc of that group
 - provide next/previous navigation

 The sidebars can be generated from the filesystem, or explicitly defined here.

 Create as many sidebars as you want.
 */

// @ts-check

/** @type {import('@docusaurus/plugin-content-docs').SidebarsConfig} */
const sidebars = {
  docs: [
    'installation',
    'dotnettemplate',
    'configuration',
    'realm/index',
    { type: 'category', label: 'Identity Management', items:[ 'idmanagement/index', 'idmanagement/azuread', 'idmanagement/samples' ] },
    { type: 'category', label: 'OAuth 2.0 and OpenID Connect', items:[ 'openidconnect/index', 'openidconnect/grant_types', 'openidconnect/clientauthmethods', 'openidconnect/clientregistration', 'openidconnect/acr' ] },
    { type: 'category', label: 'Financial-grade API (FAPI)', items: [ 'fapi/index', 'fapi/securityprofile', 'fapi/ciba', 'fapi/grantmgt' ] },
    { type: 'category', label: 'Verifiable Credentials', items: ['verifiablecredentials/index', 'verifiablecredentials/credissuer', 'verifiablecredentials/did'] },
    'pki/index',
    'auditing/index',
    { type: 'category', label: 'Administration UI', items : [ 'adminui/index', 'adminui/realm', 'adminui/externalidproviders', 'adminui/certificateauthority' ] }
  ],
  tutorials: [
    'tutorial/overview',    
    { 
      type: 'category', 
      label: 'Tutorial',       
      items: [ 'tutorial/spa', 'tutorial/regularweb', 'tutorial/protectapi', 'tutorial/m2m', 'tutorial/highlysecuredregularweb', 'tutorial/ciba', 'tutorial/grantmgt' ] 
    }
  ]
  // By default, Docusaurus generates a sidebar from the docs folder structure
  /*
  documentationSidebar: [
    {type: 'autogenerated', dirName: '.'}
  ]
  */
};

module.exports = sidebars;
