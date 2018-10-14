import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Product from './components/Product';
import Login from './components/Login';


export default () => (
	<Layout>
		<Route path='/home' component={Home} />

		<Route path='/login' component={Login} />
		<Route path='/product' component={Product} />
	</Layout>
);
