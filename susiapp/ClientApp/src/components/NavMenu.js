import React from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem, FormGroup, FormControl, Button } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export default props => (
	<Navbar inverse fixedTop fluid collapseOnSelect>
		<Navbar.Header>
			<Navbar.Brand>
				<Link to={'/'}>susi_app</Link>
			</Navbar.Brand>
			<Navbar.Toggle />
		</Navbar.Header>
		<Navbar.Collapse>
			<Nav>
				<LinkContainer to={'/home'} exact>
					<NavItem>
						<Glyphicon glyph='home' />DashBoard
					</NavItem>
				</LinkContainer>
				<LinkContainer to={'/login'}>
					<NavItem>
						<Glyphicon glyph='login' />Login
					</NavItem>
				</LinkContainer>
			</Nav>


		</Navbar.Collapse>

	</Navbar>
);
