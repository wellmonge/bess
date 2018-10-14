import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/Product';

class Product extends Component {
	componentWillMount() {
		// This method runs when the component is first added to the page
		//const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
		this.props.requestProducts();
	}

	componentWillReceiveProps(nextProps) {
		// This method runs when incoming props (e.g., route params) change
		//const startDateIndex = parseInt(nextProps.match.params.startDateIndex, 10) || 0;
		this.props.requestProducts();

	}

	render() {
		return (
			<div>
				<h1>Product List</h1>
				<p>List of products on sales.</p>
				{renderProductsTable(this.props)}
			</div>
		);
	}
}

function renderProductsTable(props) {
	return (
		<table className='table'>
			<thead>
				<tr>
					<th>Description</th>
					<th>Code</th>
				</tr>
			</thead>
			<tbody>
				{props.products.map(item =>
					<tr key={item.description}>
						<td>{item.description}</td>
						<td>{item.code}</td>>
					</tr>
				)}
			</tbody>
		</table>
	);
}

function renderPagination(props) {
	const prevStartDateIndex = (props.startDateIndex || 0) - 5;
	const nextStartDateIndex = (props.startDateIndex || 0) + 5;

	return <p className='clearfix text-center'>
		<Link className='btn btn-default pull-left' to={`/fetchdata/${prevStartDateIndex}`}>Previous</Link>
		<Link className='btn btn-default pull-right' to={`/fetchdata/${nextStartDateIndex}`}>Next</Link>
		{props.isLoading ? <span>Loading...</span> : []}
	</p>;
}

export default connect(
	state => state.products,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Product);
